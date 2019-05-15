using System.Collections.Generic;
using System;

namespace GPLexTutorial.AST
{
    public abstract class Node
    {

        //Provided by tutor 
        void Indent(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write("    ");
        }

        public void DumpValue(int indent = 0)
        {
            Indent(indent);
            Console.WriteLine("{0}", GetType().ToString());

            Indent(indent);
            Console.WriteLine("{");

            foreach (var field in GetType().GetFields(System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Instance))
            {
                object value = field.GetValue(this);
                Indent(indent + 1);

                if (value is System.Collections.IEnumerable && value.GetType().IsGenericType)
                {
                    Console.WriteLine("{0}:", field.Name);
                    Indent(indent + 1);
                    Console.WriteLine("{");

                    foreach (object item in (System.Collections.IEnumerable)value)
                    {
                        if (item is Node)
                        {
                            ((Node)item).DumpValue(indent + 2);
                        }
                        else
                        {
                            Indent(indent + 2);
                            Console.WriteLine("{0}", item);
                        }
                    }

                    Indent(indent + 1);
                    Console.WriteLine("}");
                }
                else if (value is Node)
                {
                    Console.WriteLine("{0}:", field.Name);
                    ((Node)value).DumpValue(indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", field.Name, value);
                }
            }

            Indent(indent);
            Console.WriteLine("}");
        }
    }





    public abstract class Statement : Node
    {
    }


    public abstract class Expression : Node
    {
        public Type type;
    }


    public abstract class Type : Node
    {
        public abstract bool Compatible(Type other);

    }


    public enum Modifier { Public, Private, Static }
    public enum Primitive { Int }





    //CompilationUnit

    public class CompilationUnit : Node
    {
        private List<Declaration> classDeclarationList;

        public CompilationUnit(List<Declaration> classDeclarationList)
        {
            this.classDeclarationList = classDeclarationList;
        }

        public override void ResolveNames(LexicalScope scope)
        {

            foreach (var decl in classDeclarationList)
            {
                decl.ResolveNames(scope);
            }

        }

        public override void TypeCheck()
        {

            foreach (var decl in classDeclarationList)
            {
                decl.TypeCheck();
            }

        }
    }



    //Decalaration


    public class Declaration : Node
    {
        public Type GetType();

        internal void ResolveNames(LexicalScope scope)
        {
            throw new NotImplementedException();
        }
    }

    public class ClassDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private string className;
        private List<Declaration> classBodyDeclarations;
        public ClassDeclaration(List<Modifier> modifiers, string className, List<Declaration> classBodyDeclarations)
        {
            this.modifiers = modifiers;
            this.className = className;
            this.classBodyDeclarations = classBodyDeclarations;
        }


        public override void ResolveNames(LexcialScope scope)
        {
            scope.Add(className, this);

            foreach (var decl in classBodyDeclarations)
            {
                decl.ResolveNames(scope);
            }
        }

        public override void TypeCheck()
        {

            foreach (Declaration decl in classBodyDeclarations)
            {
                decl.TypeCheck();
            }

        }

    }



    public class MethodDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private Type returnType;
        private string methodName;
        private List<FormalParameterDeclaration> formalParameterList;
        private Block methodBody;

        public MethodDeclaration(List<Modifier> modifiers, Type returnType, string methodName, List<FormalParameterDeclaration> formalParameterList, Block methodBody)
        {
            this.modifiers = modifiers;
            this.returnType = returnType;
            this.methodName = methodName;
            this.formalParameterList = formalParameterList;
            this.methodBody = methodBody;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            scope.Add(methodName, this);
            foreach (var child in formalParameterList)
                child.ResolveNames(scope);
            methodBody.ResolveNames(scope);

        }
        public override void TypeCheck()
        {
            foreach (var child in formalParameterList)
                child.TypeCheck();
            methodBody.TypeCheck();
        }

    }





    //Statement 

    public class Block : Statement
    {
        private List<Statement> blockStatements;

        public Block(List<Statement> blockStatements)
        {
            this.blockStatements = blockStatements;
        }


        public override void ResolveNames(LexicalScope scope)
        {

            foreach (var child in blockStatements)
            {
                child.ResolveNames(scope);
            }
        }

        public override void TypeCheck()
        {
            foreach (var child in blockStatements)
            {
                child.TypeCheck();
            }
        }
    }


    public class VariableDeclarationStatement : Statement
    {
        private Type type;
        private List<VariableDeclarator> variables;

        public VariableDeclarationStatement(Type type, List<VariableDeclarator> variables)
        {
            this.type = type;
            this.variables = variables;
        }

        public override void ResolveNames(LexcialScope scope)
        {
            foreach (var child in variables)
            {
                child.ResolveNames(scope);
            }
        }

        public override void TypeCheck()
        {
            foreach (var child in variables)
            {
                child.TypeCheck();
            }
        }
    }



    public class VariableDeclarator : Declaration
    {
        private Type type;
        private string variableName;
        private Expression initializer;

        public VariableDeclarator(string variableName, Expression initializer)
        {
            this.variableName = variableName;
            this.initializer = initializer;
        }

        public void SetType(Type type)
        {
            this.type = type;
        }



        public override void ResolveNames(LexicalScope scope)
        {
            scope.Add(variableName, this);
            initializer.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
            type.TypeCheck();
            initializer.TypeCheck();
        }
    }



    public class ExpressionStatement : Statement
    {
        private Expression expression;

        public ExpressionStatement(Expression expression)
        {
            this.expression = expression;
        }

        public override void ResolveNames(LexcialScope scope)
        {
            expression.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
            expression.TypeCheck();
        }
    }


    public class ArrayType : Type
    {
        private Type type;

        public ArrayType(Type type)
        {
            this.type = type;
        }

        public override bool Compatible(Type other)
        {
            if (other is ArrayType)
                return ((ArrayType)other).type.Compatible(this.type);
            else
                return false;
        }

    }

    public class NamedType : Type
    {
        private string name;

        public NamedType(string name)
        {
            this.name = name;
        }

        public override bool Compatible(Type other)
        {
            if (other is NamedType)
                return ((NamedType)other).name.Equals(name);
            else
                return false;
        }

    }

    public class PrimitiveType : Type
    {
        private Primitive type;

        public PrimitiveType(Primitive type)
        {
            this.type = type;
        }

        public override bool Compatible(Type other)
        {
            if (other is PrimitiveType)
                return ((PrimitiveType)other).type.Equals(this.type);
            else
                return false;
        }

    }

    public class AssignmentExpression : Expression
    {
        private Expression lhs;
        private string operation;
        private Expression rhs;

        public AssignmentExpression(Expression lhs, string operation, Expression rhs)
        {
            this.lhs = lhs;
            this.operation = operation;
            this.rhs = rhs;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            if (scope != null)
                declaration = scope.Resolve(operation);
            if (declaration == null)
            {
                Console.WriteLine("Error: {0}", operation);
                throw new Exception(operation + " does not exist");
            }
        }

        public override void TypeCheck()
        {
            lhs.TypeCheck();
            if (!lhs.type.Compatible(declaration.GetType()))
            {
                Console.WriteLine("error\n");
                throw new Exception("TypeCheck error");
            }
            type = lhs.type;
        }


    }

    public class IdentifierExpression : Expression
    {
        private string identifierName;
        private Declaration dec;

        public IdentifierExpression(string identifierName)
        {
            this.identifierName = identifierName;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            dec = table.lookUp(identifierName);
        }

        public override void TypeCheck()
        {
            type = dec.GetType();
        }
    }

    public class IntegerLiteralExpression : Expression
    {
        private int value;

        public IntegerLiteralExpression(int value)
        {
            this.value = value;
        }


        public override void TypeCheck()
        {
            type = new PrimitiveType(Primitive.Int);
        }
    }

    public class FormalParameterDeclaration : Declaration
    {
        private Type type;
        private string identifier;

        public FormalParameterDeclaration(Type type, string identifier)
        {
            this.type = type;
            this.identifier = identifier;
        }


        public override void ResolveNames(LexicalScope scope)
        {
            scope.Add(identifier, this);
            type.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
            type.TypeCheck();
        }
    }
}