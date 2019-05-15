using System.Collections.Generic;
using System;
using System.IO;

namespace GPLexTutorial.AST
{
	public abstract class Node
	{
        public abstract void ResolveNames(SymbolTable table);
        public abstract void TypeCheck();

        public abstract void CodeGeneration(StreamWriter sw);
        
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
                else if (value is SymbolTable)
                {
                    Console.WriteLine("{0}:", field.Name);
                    ((SymbolTable)value).Dump();
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

	
	public abstract class Declaration : Node
	{
        public abstract void AddToSymbolTable(SymbolTable symblTable);
        public abstract new Type GetType();
                
    }

	
	public abstract class Statement : Node
	{
    }

	
	public abstract class Expression: Node
	{
        public Type type;

        public abstract void StoreCodeGeneration(StreamWriter sw);
	}

	
	public abstract class Type: Node
	{
        public abstract bool Compatible(Type other);
                        
	}

	
	public enum Modifier {  Public, Private, Static }
	public enum Primitive { Int }

	public class CompilationUnit : Node
	{
		private List<Declaration> classDeclarationList;
        private SymbolTable symbolTable;

		public CompilationUnit(List<Declaration> classDeclarationList)
		{
			this.classDeclarationList = classDeclarationList;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write(".assembly ConsoleApp1 {}\n");

            foreach (Declaration d in classDeclarationList)
            {
                d.CodeGeneration(sw);
            }
        }

        public override void ResolveNames(SymbolTable parent)
        {
            symbolTable = new SymbolTable(parent);

            foreach (var decl in classDeclarationList)
            {
                decl.AddToSymbolTable(symbolTable);
            }

            foreach ( var decl in classDeclarationList)
            {
                decl.ResolveNames(symbolTable);
            }
        }

        public override void TypeCheck()
        {

            foreach (Declaration d in classDeclarationList)
            {
                d.TypeCheck();
            }
        
        }
    }

    public class ClassDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private string className;
        private List<Declaration> classBodyDeclarations;
        private SymbolTable classSymbolTable;

        public ClassDeclaration(List<Modifier> modifiers, string className, List<Declaration> classBodyDeclarations)
        {
            this.modifiers = modifiers;
            this.className = className;
            this.classBodyDeclarations = classBodyDeclarations;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            classSymbolTable = new SymbolTable(parent);

            foreach (var cldec in classBodyDeclarations)
            {
                cldec.AddToSymbolTable(classSymbolTable);
            }

            foreach (var cldec in classBodyDeclarations)
            {
                cldec.ResolveNames(classSymbolTable);
            }
        }

        public override void AddToSymbolTable(SymbolTable symblTable)
        {
            symblTable.Add(className, this);
        }

        public override void TypeCheck()
        {

            foreach (Declaration dec in classBodyDeclarations)
            {
                dec.TypeCheck();
            }

        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write(".class ");

            foreach (Modifier m in modifiers)
                sw.Write("{0} ", m.ToString().ToLower());

            sw.Write("{0} {{\n", className);

            foreach (Declaration d in classBodyDeclarations)
            {
                d.CodeGeneration(sw);
            }

            sw.Write("}");
            
        }
    }

    public class MethodDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private Type returnType;
        private string methodName;
        private List<FormalParameterDeclaration> formalParameterList;
        private Block methodBody;
        private SymbolTable methodSymbolTable;

        public MethodDeclaration(List<Modifier> modifiers, Type returnType, string methodName, List<FormalParameterDeclaration> formalParameterList, Block methodBody)
        {
            this.modifiers = modifiers;
            this.returnType = returnType;
            this.methodName = methodName;
            this.formalParameterList = formalParameterList;
            this.methodBody = methodBody;
        }
     
        public void SetReturnType(Type type)
        {
            returnType = type;
        }

        public void SetModifier(List <Modifier> mList)
        {
            modifiers = mList;
        }

        public void SetMethodBody (Block MethodBody)
        {
            this.methodBody = MethodBody;
        }
        public override void AddToSymbolTable(SymbolTable symblTable)
        {
            symblTable.Add(methodName, this);
        }

        public override void ResolveNames(SymbolTable parent)
        {
            methodSymbolTable = new SymbolTable(parent);

            foreach (var frlst in formalParameterList)
            {
                frlst.AddToSymbolTable(methodSymbolTable);
            }

            foreach (var frlst in formalParameterList)
            {
                frlst.ResolveNames(methodSymbolTable);
            }

            returnType.ResolveNames(methodSymbolTable);
            methodBody.ResolveNames(methodSymbolTable);

        }

        public override void TypeCheck()
        {
            returnType.TypeCheck();
            foreach(FormalParameterDeclaration f in formalParameterList)
            {
                f.TypeCheck();
            }
            methodBody.TypeCheck();
        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write("\t.method ");

            foreach (Modifier m in modifiers)
                sw.Write("{0} ", m.ToString().ToLower());

            returnType.CodeGeneration(sw);
                        
            sw.Write(" {0} (", methodName);

            foreach (FormalParameterDeclaration fd in formalParameterList)
                fd.CodeGeneration(sw);

            sw.Write(") \n \t{\n");

            if (methodName.ToLower().Equals("main"))
                sw.Write("\t\t.entrypoint \n");

            methodBody.CodeGeneration(sw);

            sw.Write("\t\tret \n \t}\n");
        }
    }


    //Statement 

    public class Block : Statement
	{
		private List<Statement> blockStatements;
        private SymbolTable blockSymboltable;

		public Block(List<Statement> blockStatements)
		{
			this.blockStatements = blockStatements;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            foreach (Statement s in blockStatements)
                s.CodeGeneration(sw);
        }

        public override void ResolveNames(SymbolTable parent)
        {
            blockSymboltable = new SymbolTable(parent);
     
            foreach (var blkstmt in blockStatements)
            {
                blkstmt.ResolveNames(blockSymboltable);
            }
        }

        public override void TypeCheck()
        {
            foreach(Statement s in blockStatements)
            {
                s.TypeCheck();
            }
        }
    }

	public class VariableDeclarationStatement: Statement
	{
		private Type type;
		private List<VariableDeclarator> variables;

        public VariableDeclarationStatement(Type type, List<VariableDeclarator> variables)
        {
            this.type = type;
            this.variables = variables;
        }

        public override void CodeGeneration(StreamWriter sw)
        {

            sw.Write("\t\t.locals init (");
            type.CodeGeneration(sw);
            foreach (VariableDeclarator d in variables)
                d.CodeGeneration(sw);
            sw.Write(")\n");

        }

        public override void ResolveNames(SymbolTable table)
        {
            type.ResolveNames(table);
            foreach(var vari in variables)
            {
                vari.AddToSymbolTable(table);
                vari.ResolveNames(table);
            }
        }

        public override void TypeCheck()
        {
            foreach(var vari in variables)
            {
                vari.SetType(type);
                vari.TypeCheck();
            }
        }
    }

    public class VariableDeclarator: Declaration
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

        public override Type GetType()
        {
            return type;
        }

        public override void AddToSymbolTable(SymbolTable symblTable)
        {
            symblTable.Add(variableName, this);
        }

        public override void ResolveNames(SymbolTable table)
        {
            if (initializer != null)
            {
                initializer.ResolveNames(table);
            }
            
        }

        public override void TypeCheck()
        {
            type.TypeCheck();

            if(initializer != null)
            {
                initializer.TypeCheck();
                type.Compatible(initializer.type);
            }
            
            
        }

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write(" {0}", variableName);
        }
    }



    public class ExpressionStatement: Statement
	{
		private Expression expression;

		public ExpressionStatement(Expression expression)
		{
			this.expression = expression;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            expression.CodeGeneration(sw);
        }

        public override void ResolveNames(SymbolTable table)
        {
            expression.ResolveNames(table);
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

        public override void CodeGeneration(StreamWriter sw)
        {
            type.CodeGeneration(sw);
            sw.Write("[] ");
        }

        public override bool Compatible(Type other)
        {
            if (other is ArrayType)
                return ((ArrayType)other).type.Compatible(this.type);
            else
                return false;
        }

        public override void ResolveNames(SymbolTable table)
        {
            type.ResolveNames(table);
        }

        public override void TypeCheck()
        {
        }
    }

	public class NamedType : Type
	{
		private string name;

		public NamedType(string name)
		{
			this.name = name;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write(name);
        }

        public override bool Compatible(Type other)
        {
            if (other is NamedType)
                return ((NamedType)other).name.Equals(name);
            else
                return false;
        }

        public override void ResolveNames(SymbolTable table)
        {
            
        }

        public override void TypeCheck()
        {
            
        }
    }

	public class PrimitiveType: Type
	{
		private Primitive type;

		public PrimitiveType(Primitive type)
		{
			this.type = type;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write("{0}", type.ToString().ToLower());
        }

        public override bool Compatible(Type other)
        {
            if (other is PrimitiveType)
                return ((PrimitiveType)other).type.Equals(this.type);
            else
                return false;
        }

        public override void ResolveNames(SymbolTable table)
        {
            
        }

        public override void TypeCheck()
        {
           
        }
    }

	public class AssignmentExpression: Expression
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

        public override void CodeGeneration(StreamWriter sw)
        {
            rhs.CodeGeneration(sw);            
            lhs.StoreCodeGeneration(sw);
        }

        public override void ResolveNames(SymbolTable table)
        {
            lhs.ResolveNames(table);
            rhs.ResolveNames(table);
        }

        public override void StoreCodeGeneration(StreamWriter sw)
        {
            throw new Exception("Can't store to Expression");
        }

        public override void TypeCheck()
        {
            lhs.TypeCheck();
            rhs.TypeCheck();

            if (!lhs.type.Compatible(rhs.type))
            {
                throw new Exception("Type of left hand side is not compatible with that of right hand side");
            }

            type = rhs.type;
        }
    }

	public class IdentifierExpression: Expression
	{
		private string identifierName;
        private Declaration dec;

		public IdentifierExpression(string identifierName)
		{
			this.identifierName = identifierName;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write("ldloc {0}\n", identifierName);
        }

        public override  void StoreCodeGeneration(StreamWriter sw)
        {
            sw.Write("\t\tstloc {0}\n", identifierName);
        }

        public override void ResolveNames(SymbolTable table)
        {
            dec = table.lookUp(identifierName);
        }

        public override void TypeCheck()
        {
            type = dec.GetType();
        }
    }

	public class IntegerLiteralExpression: Expression
	{
		private int value;

		public IntegerLiteralExpression(int value)
		{
			this.value = value;
		}

        public override void CodeGeneration(StreamWriter sw)
        {
            sw.Write("\t\tldc.i4 {0}\n", value + "");
        }

        public override void ResolveNames(SymbolTable table)
        {
            
        }

        public override void StoreCodeGeneration(StreamWriter sw)
        {
            throw new Exception("Can't store to IntegerLiteralExpression");
        }

        public override void TypeCheck()
        {
            type = new PrimitiveType(Primitive.Int);
        }
    }

	public class FormalParameterDeclaration: Declaration
	{
		private Type type;
		private string identifier;

		public FormalParameterDeclaration(Type type, string identifier)
		{
			this.type = type;
			this.identifier = identifier;
		}

        public override void AddToSymbolTable(SymbolTable symblTable)
        {
            symblTable.Add(identifier, this);
        }

        public override void CodeGeneration(StreamWriter sw)
        {
            type.CodeGeneration(sw);
            sw.Write(identifier);
        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(SymbolTable table)
        {
            type.ResolveNames(table);
        }

        public override void TypeCheck()
        {
            type.TypeCheck();
        }
    }
    public class BinaryExpression : Expression
    {
        private IdentifierExpression identifierExpression;
        private string v;
        private IntegerLiteralExpression integerLiteralExpression;

        public BinaryExpression(IdentifierExpression identifierExpression, string v, IntegerLiteralExpression integerLiteralExpression)
        {
            this.identifierExpression = identifierExpression;
            this.v = v;
            this.integerLiteralExpression = integerLiteralExpression;
        }

        public override void CodeGeneration(StreamWriter sw)
        {
            identifierExpression.CodeGeneration(sw);
            switch(v)
            {
                case "+":
                    sw.Write(" add ");
                    break;
                case "*":
                    sw.Write(" mul ");
                    break;
                case "-":
                    sw.Write(" sub ");
                    break;
                case "\\":
                    sw.Write(" div ");
                    break;
            }
            integerLiteralExpression.CodeGeneration(sw);
            
        }

        public override void StoreCodeGeneration(StreamWriter sw)
        {
            throw new Exception("Can't store to BinaryExpression");
        }

        public override void ResolveNames(SymbolTable table)
        {
            throw new NotImplementedException();
        }

        public override void TypeCheck()
        {
            throw new NotImplementedException();
        }
    }
}