using System;
using System.Collections.Generic;


namespace AST
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

                // Is this value something we can iterate through?
                // We test that it is a generic type, this way we don't treat strings as IEnumerables.
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


    /* --------------------------------------------------------CompilationUnit--------------------------------------------------------------- */

    /* List all three declarations which identified in JAVA SE Specification */

    public class CompilationUnit : Node
    {
        private PackageDeclaration packageDeclaration;
        private ImportDeclaration importDeclaration;
        private List<TypeDeclaration> typeDeclaration;

        public CompilationUnit(PackageDeclaration packageDeclaration, ImportDeclaration importDeclaration, List<TypeDeclaration> typeDeclaration)
        {
            this.packageDeclaration = packageDeclaration;
            this.importDeclaration = importDeclaration;
            this.typeDeclaration = typeDeclaration;
        }

    }



    /*  --------------------------------------------------------Declaration--------------------------------------------------------------- */

    /* Identify three declarations */

    public class PackageDeclaration : Node
    {

    }

    public class ImportDeclaration : Node
    {

    }

    public class TypeDeclaration : Node
    {

    }


    /* Identify ClassDeclaration which is contained in TypeDeclaration */

    public class ClassDeclaration : TypeDeclaration
    {

        /* Ignore NormalClassDeclaration and only list 'ClassModfiers', 'CLASS' and 'ClassBodyDeclaration' */

        private List<ClassModifier> classModifier;
        private string ClassName;
        private List<ClassBodyDeclaration> classBodyDeclarations;

        public ClassDeclaration(List<ClassModifier> classModifier, string ClassName, List<ClassBodyDeclaration> classBodyDeclarations)
        {
            this.classModifier = classModifier;
            this.ClassName = ClassName;
            this.classBodyDeclarations = classBodyDeclarations;
        }


    }


    /*  --------------------------------------------------------Modifiers--------------------------------------------------------------- */

    /* ClassModifier */

    public enum ClassModifier
    {
        Public, Protected, Private, Abstract, Static, Final, Strictfp
    }

    /* ClassBody */

    public abstract class ClassBodyDeclaration : Node
    {

    }

    /* Only select MethodDeclaration for matching the requirement of test file */
    public class MethodDeclaration : ClassBodyDeclaration
    {
        private List<MethodModifier> methodModifier;

        private MethodHeader methodHeader;
        private MethodBody methodBody;
        public MethodDeclaration(List<MethodModifier> methodModifier, MethodHeader methodHeader,
            MethodBody methodBody)
        {
            this.methodModifier = methodModifier;
            this.methodHeader = methodHeader;
            this.methodBody = methodBody;
        }

    }

    /* MethodeHeader */
    public class MethodHeader : Node
    {
        private Type returnType;
        private MethodDeclarator methodDeclarator;

        public MethodHeader(Type returnType, MethodDeclarator methodDeclarator)
        {
            this.methodDeclarator = methodDeclarator;
            this.returnType = returnType;
        }
    }


    /* MethodModifier */
    public enum MethodModifier
    {
        Public, Protected, Private, Abstract, Static, Final, Synchronized, native, Strictfp
    }


    /* MethodDeclarator */
    public class MethodDeclarator : Node
    {
        /* Mname is method name*/
        private string Mname_identifier;
        private List<FormalParameter> formalParameter;
        public MethodDeclarator(string Mname_identifier, List<FormalParameter> formalParameter)
        {
            this.Mname_identifier = Mname_identifier;
            this.formalParameter = formalParameter;
        }
    }


    /* FormalParameter */

    public abstract class Parameter : Node
    {

    }

    public class FormalParameter : Parameter
    {
        private Type unannArrayType;

        /* 'identifier is contained in 'VariableDeclaratorID' */
        private string identifiers;
        public FormalParameter(Type unannArrayType, string identifiers)
        {
            this.unannArrayType = unannArrayType;
            this.identifiers = identifiers;
        }

    }




    /*  --------------------------------------------------------Type--------------------------------------------------------------- */

    /* Type - There are 4 type's name (VOID, INT) that will be listed for the project */

    public class Type
    {
        /* The defination of 'NamedType' will be stated in next part */
        public static Type VOID = new NamedType("void");
        public static Type INT = new NamedType("int");
    }

    public class NamedType : Type
    {
        /* 'tname' is type name */
        public string tname;
        public NamedType(string tname)
        {
            this.tname = tname;
        }

    }

    public class ArrayType : Type
    {
        public Type PrimitiveType;
        public ArrayType(Type PrimitiveType)
        {
            this.PrimitiveType = PrimitiveType;
        }
    }

    public class PrimitiveType : Type
    {
        private Primitive type;

        public PrimitiveType(Primitive type)
        {
            this.type = type;
        }
    }

    /*  --------------------------------------------------------Statement--------------------------------------------------------------- */

    public abstract class Statement : Node
    {

    }

    /* MethodBody */
    public class MethodBody : Statement
    {
        /* 'Statement' - 'Block' - 'BlockStatment' - 'statement' */
        private List<Statement> block;
        public MethodBody(List<Statement> block)
        {
            this.block = block;
        }
    }


    /* LocalVariableDeclarationStatement */
    public class LocalVariableDeclarationStatement : Statement

    {
        private Type unanntype;
        private string variableName;

        public LocalVariableDeclarationStatement(Type unanntype, string variableName)
        {
            this.unanntype = unanntype;
            this.variableName = variableName;
        }
    }

    /* Primitive */

    public enum Primitive
    {
        Int
    }

    /* ExpressionStatement will be deployed for this project */
    public class ExpressionStatement : Statement
    {
        /* Assignmetn will be defined in the part of Expression */
        private AssignmentExpression assignmentexpression;
        public ExpressionStatement(AssignmentExpression assignmentExpression)
        {
            this.assignmentexpression = assignmentExpression;
        }
    }


    /*  --------------------------------------------------------Expression--------------------------------------------------------------- */

    public abstract class Expression : Node
    {

    }
    public class AssignmentExpression : Expression
    {
        private string lhs;
        private string operation;
        private Expression rhs;

        public AssignmentExpression(string lhs, string operation, Expression rhs)
        {
            this.lhs = lhs;
            this.operation = operation;
            this.rhs = rhs;
        }
    }

    /* IntegerExpression */

    public class IntExpression : Expression
    {
        private string integerLiteral;
        public IntExpression(string integerLiteral)
        {
            this.integerLiteral = integerLiteral;
        }
    }

    /* IdentifierExpression */
    public class IdentExpression : Expression
    {
        private string identifier;
        public IdentExpression(string identifier)
        {
            this.identifier = identifier;
        }
    }


}


/*  --------------------------------------------------------End--------------------------------------------------------------- */
