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
            TestAST();


            //Scanner scanner = new Scanner(
            //        new FileStream(args[0], FileMode.Open));
            //Parser parser = new Parser(scanner);
            //parser.Parse();

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

            var program = new AST.CompilationUnit(
            /* Null is for PackageDec and ImportDec*/
                null,
                null,
                new List<AST.TypeDeclaration>
                {
                    new AST.ClassDeclaration(

                        new List<AST.ClassModifier> { AST.ClassModifier.Public },
                        "HelloWorld",
                        new List<AST.ClassBodyDeclaration>
                        {
                            new AST.MethodDeclaration(
                                new List<AST.MethodModifier> { AST.MethodModifier.Public, AST.MethodModifier.Static},
                                new AST.MethodHeader (AST.Type.VOID,
                                    new AST.MethodDeclarator(
                                    "main",
                                    new List<AST.FormalParameter>
                                    {
                                        new AST.FormalParameter(
                                            new AST.ArrayType(new AST.NamedType("String")), "args")})),
                                new AST.MethodBody(
                                    new List<AST.Statement>
                                    {
                                        new AST.LocalVariableDeclarationStatement(new AST.PrimitiveType(AST.Primitive.Int),"x"),

                                        new AST.ExpressionStatement(
                                            new AST.AssignmentExpression(
                                                "x",
                                                "=",
                                                new AST.IntExpression("42")
                                               )
                                            )
                                    }
                                   )
                                  )
                        }
                       )
                }
               );
            program.DumpValue(0);
        }
    }



}
