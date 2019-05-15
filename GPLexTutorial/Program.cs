using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GPLexTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestAST();



            Scanner scanner = new Scanner(
                    new FileStream(args[0], FileMode.Open));
            Parser parser = new Parser(scanner);
            parser.Parse();
            parser.Root.ResolveNames(null);
            parser.Root.DumpValue();

            StreamWriter sw = new StreamWriter("program.il");
            parser.Root.CodeGeneration(sw);
            sw.Close();

            //Tokens token;

            //do
            //{
            //    token = (Tokens)scanner.yylex();
            //    Console.WriteLine("token {0}", token);
            //}
            //while (token != Tokens.EOF);
        }

        static void TestAST()
        {

            var program = new AST.CompilationUnit(new List<AST.Declaration> { new AST.ClassDeclaration(
                new List<AST.Modifier> { AST.Modifier.Public },
                ("Helloworld"),
                new List<AST.Declaration> {
                    new AST.MethodDeclaration(
                        new List<AST.Modifier> { AST.Modifier.Public, AST.Modifier.Static },
                        new AST.NamedType("void"),
                        "main",
                        new List<AST.FormalParameterDeclaration> {
                                    new AST.FormalParameterDeclaration(
                                        new AST.ArrayType(new AST.NamedType("String")),
                                        "args"
                                    )
                        },


                        new AST.Block(
                            new List<AST.Statement> {
                                new AST.VariableDeclarationStatement(new AST.PrimitiveType(AST.Primitive.Int), new List<AST.VariableDeclarator>{new AST.VariableDeclarator("x", null) }),
                                new AST.VariableDeclarationStatement(new AST.PrimitiveType(AST.Primitive.Int), new List<AST.VariableDeclarator>{new AST.VariableDeclarator("y", null) }),
                                new AST.ExpressionStatement(
                                    new AST.AssignmentExpression(
                                        new AST.IdentifierExpression ("x"),
                                        "=",
                                        new AST.IntegerLiteralExpression(42) //42 is changed to "42"

                                    )
                                ),
                                new AST.ExpressionStatement(new AST.AssignmentExpression(new AST.IdentifierExpression("y"), "=",new AST.BinaryExpression(new AST.IdentifierExpression("x"),"+", new AST.IntegerLiteralExpression(1))))
                            }
                        )
                    )
                })
                }
            );
            program.ResolveNames(null);
            program.DumpValue(0);
        }
    }

  

}
