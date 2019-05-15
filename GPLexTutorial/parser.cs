// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  CHC-PC
// DateTime: 2019/5/15 11:59:37
// UserName: chc
// Input file <parser1.y - 2019/5/15 11:41:19>

// options: conflicts lines gplex conflicts

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace GPLexTutorial
{
public enum Tokens {
    error=127,EOF=128,NUMBER=129,IDENTIFIER=130,IF=131,ELSE=132,
    INT=133,BOOL=134,ABSTRACT=135,ASSERT=136,BOOLEAN=137,BREAK=138,
    BYTE=139,CASE=140,CATCH=141,CHAR=142,CLASS=143,CONST=144,
    CONTINUE=145,DEFAULT=146,DO=147,DOUBLE=148,ENUM=149,EXTENDS=150,
    FINAL=151,FINALLY=152,FLOAT=153,FOR=154,GOTO=155,IMPLEMENTS=156,
    IMPORT=157,INSTANCEOF=158,INTERFACE=159,LONG=160,NATIVE=161,NEW=162,
    PACKAGE=163,PRIVATE=164,PROTECTED=165,PUBLIC=166,RETURN=167,SHORT=168,
    STATIC=169,STRICTFP=170,SUPER=171,SWITCH=172,SYNCHRONIZED=173,THIS=174,
    THROW=175,THROWS=176,TRANSIENT=177,TRY=178,VOID=179,VOLATILE=180,
    WHILE=181,_=182,STRINGL=183,OPERATOR=184,ASSIGNMENT=185,SEPARATOR=186,
    CHARACTERL=187,TRUE=188,FALSE=189,NULL=190,INT_LITERAL=191,DEC_FPL=192,
    HEX_FPL=193};

public struct ValueType
#line 4 "parser1.y"
{
	
	public int num;
	public string name;
	public string keywords;
	public string stri;
	public string operato;
	public string assignment;
	public string separator;
	public string character;
	public string Boolean_Literal;
	public string Null_literal;
	public int Int_Literal;
	public string Dec_FPL;
	public string Hex_FPL;

	public AST.CompilationUnit comp;
	public AST.Node node;
	public AST.Declaration dec;
	public AST.VariableDeclarator declarator;
	public AST.FormalParameterDeclaration formalDec;
	public System.Collections.Generic.List<AST.Declaration> decList;
	public System.Collections.Generic.List<AST.VariableDeclarator> declaratorList;
	public System.Collections.Generic.List<AST.FormalParameterDeclaration> formalDecList;
	public AST.Statement stmt;
	public System.Collections.Generic.List<AST.Statement> stmtList;
	public AST.Expression expr;
	public AST.Type typ;
	public AST.NamedType nametyp;
	public AST.Modifier mod;
	public System.Collections.Generic.List<AST.Modifier> modList;
	public AST.MethodDeclaration mtdDec;
	public AST.Block block;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[94];
  private static State[] states = new State[115];
  private static string[] nonTerms = new string[] {
      "CompilationUnit", "OrdinaryCompilationUnit", "TypeDeclarations", "TypeDeclaration", 
      "ClassDeclaration", "NormalClassDeclaration", "ClassModifiers", "ClassModifier", 
      "TypeIdentifier", "ClassBody", "ClassBodyDeclarations", "ClassBodyDeclaration", 
      "ClassMemberDeclaration", "MethodDeclaration", "MethodModifiers", "MethodModifier", 
      "MethodHeader", "Result", "MethodDeclarator", "FormalParameterList_opt", 
      "FormalParameterList", "FormalParameter", "VariableDeclaratorId", "LocalVariableType", 
      "UnannType", "UnannPrimitiveType", "NumericType", "IntegralType", "UnannReferenceType", 
      "UnannArrayType", "UnannClassOrInterfaceType", "UnannClassType", "MethodBody", 
      "Block", "BlockStatements_opt", "BlockStatements", "BlockStatement", "LocalVariableDeclarationStatement", 
      "LocalVariableDeclaration", "VariableDeclaratorList", "VariableDeclarators", 
      "VariableDeclarator", "Statement", "StatementWithoutTrailingSubstatement", 
      "ExpressionStatement", "StatementExpression", "Assignment", "LeftHandSide", 
      "ExpressionName", "AssignmentOperator", "Expression", "AssignmentExpression", 
      "ConditionalExpression", "ConditionalOrExpression", "ConditionalAndExpression", 
      "InclusiveOrExpression", "ExclusiveOrExpression", "AndExpression", "EqualityExpression", 
      "RelationalExpression", "ShiftExpression", "AdditiveExpression", "MultiplicativeExpression", 
      "UnaryExpression", "UnaryExpressionNotPlusMinus", "PostfixExpression", 
      "Primary", "PrimaryNoNewArray", "Literal", "VariableInitializer_opt", "$accept", 
      "PackageDeclaration_opt", "ImportDeclarations", "TypeParameters_opt", "Superclass_opt", 
      "Superinterfaces_opt", "Throws_opt", "ReceiverParameter_opt", "Dims_opt", 
      "VariableModifiers", "Dims", "TypeArguments_opt", "Annotations", "Annotation_opt", 
      };

  static Parser() {
    states[0] = new State(-4,new int[]{-1,1,-2,3,-72,4});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(-5,new int[]{-73,5});
    states[5] = new State(new int[]{143,-12,166,-12,128,-7},new int[]{-3,6,-4,7,-5,9,-6,10,-7,11});
    states[6] = new State(-3);
    states[7] = new State(new int[]{143,-12,166,-12,128,-7},new int[]{-3,8,-4,7,-5,9,-6,10,-7,11});
    states[8] = new State(-6);
    states[9] = new State(-8);
    states[10] = new State(-9);
    states[11] = new State(new int[]{143,12,166,114},new int[]{-8,113});
    states[12] = new State(new int[]{130,58},new int[]{-9,13});
    states[13] = new State(-15,new int[]{-74,14});
    states[14] = new State(-16,new int[]{-75,15});
    states[15] = new State(-17,new int[]{-76,16});
    states[16] = new State(new int[]{123,18},new int[]{-10,17});
    states[17] = new State(-10);
    states[18] = new State(new int[]{166,111,169,112,125,-19,179,-24},new int[]{-11,19,-12,21,-13,23,-14,24,-15,25,-16,109});
    states[19] = new State(new int[]{125,20});
    states[20] = new State(-18);
    states[21] = new State(new int[]{166,111,169,112,125,-19,179,-24},new int[]{-11,22,-12,21,-13,23,-14,24,-15,25,-16,109});
    states[22] = new State(-20);
    states[23] = new State(-21);
    states[24] = new State(-22);
    states[25] = new State(new int[]{179,108},new int[]{-17,26,-18,94});
    states[26] = new State(new int[]{123,29},new int[]{-33,27,-34,28});
    states[27] = new State(-23);
    states[28] = new State(-53);
    states[29] = new State(-56,new int[]{-35,30,-36,32});
    states[30] = new State(new int[]{125,31});
    states[31] = new State(-54);
    states[32] = new State(new int[]{130,93,125,-55,133,-38},new int[]{-37,33,-38,34,-39,35,-80,37,-43,63,-44,64,-45,65,-46,66,-47,68,-48,69,-49,92});
    states[33] = new State(-57);
    states[34] = new State(-58);
    states[35] = new State(new int[]{59,36});
    states[36] = new State(-60);
    states[37] = new State(new int[]{130,58,133,62},new int[]{-24,38,-25,46,-29,47,-30,48,-31,49,-32,55,-9,56,-26,59,-27,60,-28,61});
    states[38] = new State(new int[]{130,44},new int[]{-40,39,-42,40,-23,42});
    states[39] = new State(-61);
    states[40] = new State(-63,new int[]{-41,41});
    states[41] = new State(-62);
    states[42] = new State(-65,new int[]{-70,43});
    states[43] = new State(-64);
    states[44] = new State(-33,new int[]{-79,45});
    states[45] = new State(-39);
    states[46] = new State(-66);
    states[47] = new State(-40);
    states[48] = new State(-45);
    states[49] = new State(-51,new int[]{-81,50,-83,51});
    states[50] = new State(-46);
    states[51] = new State(new int[]{91,52});
    states[52] = new State(new int[]{93,53});
    states[53] = new State(-52,new int[]{-84,54});
    states[54] = new State(-50);
    states[55] = new State(-47);
    states[56] = new State(-49,new int[]{-82,57});
    states[57] = new State(-48);
    states[58] = new State(-14);
    states[59] = new State(-41);
    states[60] = new State(-42);
    states[61] = new State(-43);
    states[62] = new State(-44);
    states[63] = new State(-59);
    states[64] = new State(-67);
    states[65] = new State(-68);
    states[66] = new State(new int[]{59,67});
    states[67] = new State(-69);
    states[68] = new State(-70);
    states[69] = new State(new int[]{61,91},new int[]{-50,70});
    states[70] = new State(new int[]{191,90},new int[]{-51,71,-52,72,-53,73,-54,74,-55,75,-56,76,-57,77,-58,78,-59,79,-60,80,-61,81,-62,82,-63,83,-64,84,-65,85,-66,86,-67,87,-68,88,-69,89});
    states[71] = new State(-71);
    states[72] = new State(-75);
    states[73] = new State(-76);
    states[74] = new State(-77);
    states[75] = new State(-78);
    states[76] = new State(-79);
    states[77] = new State(-80);
    states[78] = new State(-81);
    states[79] = new State(-82);
    states[80] = new State(-83);
    states[81] = new State(-84);
    states[82] = new State(-85);
    states[83] = new State(-86);
    states[84] = new State(-87);
    states[85] = new State(-88);
    states[86] = new State(-89);
    states[87] = new State(-90);
    states[88] = new State(-91);
    states[89] = new State(-92);
    states[90] = new State(-93);
    states[91] = new State(-74);
    states[92] = new State(-72);
    states[93] = new State(-73);
    states[94] = new State(new int[]{130,97},new int[]{-19,95});
    states[95] = new State(-30,new int[]{-77,96});
    states[96] = new State(-28);
    states[97] = new State(new int[]{40,98});
    states[98] = new State(-32,new int[]{-78,99});
    states[99] = new State(new int[]{41,-34,130,-38,133,-38},new int[]{-20,100,-21,103,-22,104,-80,105});
    states[100] = new State(new int[]{41,101});
    states[101] = new State(-33,new int[]{-79,102});
    states[102] = new State(-31);
    states[103] = new State(-35);
    states[104] = new State(-36);
    states[105] = new State(new int[]{130,58,133,62},new int[]{-25,106,-29,47,-30,48,-31,49,-32,55,-9,56,-26,59,-27,60,-28,61});
    states[106] = new State(new int[]{130,44},new int[]{-23,107});
    states[107] = new State(-37);
    states[108] = new State(-29);
    states[109] = new State(new int[]{166,111,169,112,179,-24},new int[]{-15,110,-16,109});
    states[110] = new State(-25);
    states[111] = new State(-26);
    states[112] = new State(-27);
    states[113] = new State(-11);
    states[114] = new State(-13);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-71, new int[]{-1,128});
    rules[2] = new Rule(-1, new int[]{-2});
    rules[3] = new Rule(-2, new int[]{-72,-73,-3});
    rules[4] = new Rule(-72, new int[]{});
    rules[5] = new Rule(-73, new int[]{});
    rules[6] = new Rule(-3, new int[]{-4,-3});
    rules[7] = new Rule(-3, new int[]{});
    rules[8] = new Rule(-4, new int[]{-5});
    rules[9] = new Rule(-5, new int[]{-6});
    rules[10] = new Rule(-6, new int[]{-7,143,-9,-74,-75,-76,-10});
    rules[11] = new Rule(-7, new int[]{-7,-8});
    rules[12] = new Rule(-7, new int[]{});
    rules[13] = new Rule(-8, new int[]{166});
    rules[14] = new Rule(-9, new int[]{130});
    rules[15] = new Rule(-74, new int[]{});
    rules[16] = new Rule(-75, new int[]{});
    rules[17] = new Rule(-76, new int[]{});
    rules[18] = new Rule(-10, new int[]{123,-11,125});
    rules[19] = new Rule(-11, new int[]{});
    rules[20] = new Rule(-11, new int[]{-12,-11});
    rules[21] = new Rule(-12, new int[]{-13});
    rules[22] = new Rule(-13, new int[]{-14});
    rules[23] = new Rule(-14, new int[]{-15,-17,-33});
    rules[24] = new Rule(-15, new int[]{});
    rules[25] = new Rule(-15, new int[]{-16,-15});
    rules[26] = new Rule(-16, new int[]{166});
    rules[27] = new Rule(-16, new int[]{169});
    rules[28] = new Rule(-17, new int[]{-18,-19,-77});
    rules[29] = new Rule(-18, new int[]{179});
    rules[30] = new Rule(-77, new int[]{});
    rules[31] = new Rule(-19, new int[]{130,40,-78,-20,41,-79});
    rules[32] = new Rule(-78, new int[]{});
    rules[33] = new Rule(-79, new int[]{});
    rules[34] = new Rule(-20, new int[]{});
    rules[35] = new Rule(-20, new int[]{-21});
    rules[36] = new Rule(-21, new int[]{-22});
    rules[37] = new Rule(-22, new int[]{-80,-25,-23});
    rules[38] = new Rule(-80, new int[]{});
    rules[39] = new Rule(-23, new int[]{130,-79});
    rules[40] = new Rule(-25, new int[]{-29});
    rules[41] = new Rule(-25, new int[]{-26});
    rules[42] = new Rule(-26, new int[]{-27});
    rules[43] = new Rule(-27, new int[]{-28});
    rules[44] = new Rule(-28, new int[]{133});
    rules[45] = new Rule(-29, new int[]{-30});
    rules[46] = new Rule(-30, new int[]{-31,-81});
    rules[47] = new Rule(-31, new int[]{-32});
    rules[48] = new Rule(-32, new int[]{-9,-82});
    rules[49] = new Rule(-82, new int[]{});
    rules[50] = new Rule(-81, new int[]{-83,91,93,-84});
    rules[51] = new Rule(-83, new int[]{});
    rules[52] = new Rule(-84, new int[]{});
    rules[53] = new Rule(-33, new int[]{-34});
    rules[54] = new Rule(-34, new int[]{123,-35,125});
    rules[55] = new Rule(-35, new int[]{-36});
    rules[56] = new Rule(-36, new int[]{});
    rules[57] = new Rule(-36, new int[]{-36,-37});
    rules[58] = new Rule(-37, new int[]{-38});
    rules[59] = new Rule(-37, new int[]{-43});
    rules[60] = new Rule(-38, new int[]{-39,59});
    rules[61] = new Rule(-39, new int[]{-80,-24,-40});
    rules[62] = new Rule(-40, new int[]{-42,-41});
    rules[63] = new Rule(-41, new int[]{});
    rules[64] = new Rule(-42, new int[]{-23,-70});
    rules[65] = new Rule(-70, new int[]{});
    rules[66] = new Rule(-24, new int[]{-25});
    rules[67] = new Rule(-43, new int[]{-44});
    rules[68] = new Rule(-44, new int[]{-45});
    rules[69] = new Rule(-45, new int[]{-46,59});
    rules[70] = new Rule(-46, new int[]{-47});
    rules[71] = new Rule(-47, new int[]{-48,-50,-51});
    rules[72] = new Rule(-48, new int[]{-49});
    rules[73] = new Rule(-49, new int[]{130});
    rules[74] = new Rule(-50, new int[]{61});
    rules[75] = new Rule(-51, new int[]{-52});
    rules[76] = new Rule(-52, new int[]{-53});
    rules[77] = new Rule(-53, new int[]{-54});
    rules[78] = new Rule(-54, new int[]{-55});
    rules[79] = new Rule(-55, new int[]{-56});
    rules[80] = new Rule(-56, new int[]{-57});
    rules[81] = new Rule(-57, new int[]{-58});
    rules[82] = new Rule(-58, new int[]{-59});
    rules[83] = new Rule(-59, new int[]{-60});
    rules[84] = new Rule(-60, new int[]{-61});
    rules[85] = new Rule(-61, new int[]{-62});
    rules[86] = new Rule(-62, new int[]{-63});
    rules[87] = new Rule(-63, new int[]{-64});
    rules[88] = new Rule(-64, new int[]{-65});
    rules[89] = new Rule(-65, new int[]{-66});
    rules[90] = new Rule(-66, new int[]{-67});
    rules[91] = new Rule(-67, new int[]{-68});
    rules[92] = new Rule(-68, new int[]{-69});
    rules[93] = new Rule(-69, new int[]{191});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // CompilationUnit -> OrdinaryCompilationUnit
#line 135 "parser1.y"
                                       { Root = ValueStack[ValueStack.Depth-1].comp; }
#line default
        break;
      case 3: // OrdinaryCompilationUnit -> PackageDeclaration_opt, ImportDeclarations, 
              //                            TypeDeclarations
#line 139 "parser1.y"
                                                                 { CurrentSemanticValue.comp = new AST.CompilationUnit(ValueStack[ValueStack.Depth-1].decList); }
#line default
        break;
      case 6: // TypeDeclarations -> TypeDeclaration, TypeDeclarations
#line 153 "parser1.y"
                                        { CurrentSemanticValue.decList = new  System.Collections.Generic.List<AST.Declaration> (); CurrentSemanticValue.decList.Add(ValueStack[ValueStack.Depth-2].dec); CurrentSemanticValue.decList.AddRange(ValueStack[ValueStack.Depth-1].decList); }
#line default
        break;
      case 7: // TypeDeclarations -> /* empty */
#line 154 "parser1.y"
                 { CurrentSemanticValue.decList = new  System.Collections.Generic.List<AST.Declaration> (); }
#line default
        break;
      case 9: // ClassDeclaration -> NormalClassDeclaration
#line 162 "parser1.y"
                                      { CurrentSemanticValue.dec = ValueStack[ValueStack.Depth-1].dec; }
#line default
        break;
      case 10: // NormalClassDeclaration -> ClassModifiers, CLASS, TypeIdentifier, 
               //                           TypeParameters_opt, Superclass_opt, 
               //                           Superinterfaces_opt, ClassBody
#line 169 "parser1.y"
                                                                                                        { CurrentSemanticValue.dec = new AST.ClassDeclaration(ValueStack[ValueStack.Depth-7].modList, ValueStack[ValueStack.Depth-5].name, ValueStack[ValueStack.Depth-1].decList); }
#line default
        break;
      case 11: // ClassModifiers -> ClassModifiers, ClassModifier
#line 173 "parser1.y"
                                 { CurrentSemanticValue.modList = ValueStack[ValueStack.Depth-2].modList; CurrentSemanticValue.modList.Add(ValueStack[ValueStack.Depth-1].mod);}
#line default
        break;
      case 12: // ClassModifiers -> /* empty */
#line 174 "parser1.y"
                  { CurrentSemanticValue.modList = new  List<AST.Modifier> (); }
#line default
        break;
      case 13: // ClassModifier -> PUBLIC
#line 178 "parser1.y"
                      {CurrentSemanticValue.mod =  AST.Modifier.Public;}
#line default
        break;
      case 14: // TypeIdentifier -> IDENTIFIER
#line 182 "parser1.y"
                         { CurrentSemanticValue.name = ValueStack[ValueStack.Depth-1].name; }
#line default
        break;
      case 18: // ClassBody -> '{', ClassBodyDeclarations, '}'
#line 203 "parser1.y"
                                       { CurrentSemanticValue.decList = ValueStack[ValueStack.Depth-2].decList; }
#line default
        break;
      case 19: // ClassBodyDeclarations -> /* empty */
#line 207 "parser1.y"
                        { CurrentSemanticValue.decList = new System.Collections.Generic.List<AST.Declaration>(); }
#line default
        break;
      case 20: // ClassBodyDeclarations -> ClassBodyDeclaration, ClassBodyDeclarations
#line 208 "parser1.y"
                                                { CurrentSemanticValue.decList = ValueStack[ValueStack.Depth-1].decList; ValueStack[ValueStack.Depth-1].decList.Add(ValueStack[ValueStack.Depth-2].dec); }
#line default
        break;
      case 21: // ClassBodyDeclaration -> ClassMemberDeclaration
#line 212 "parser1.y"
                                 { CurrentSemanticValue.dec = ValueStack[ValueStack.Depth-1].dec; }
#line default
        break;
      case 22: // ClassMemberDeclaration -> MethodDeclaration
#line 216 "parser1.y"
                              { CurrentSemanticValue.dec = ValueStack[ValueStack.Depth-1].mtdDec; }
#line default
        break;
      case 23: // MethodDeclaration -> MethodModifiers, MethodHeader, MethodBody
#line 224 "parser1.y"
                                              { CurrentSemanticValue.mtdDec = ValueStack[ValueStack.Depth-2].mtdDec; ValueStack[ValueStack.Depth-2].mtdDec.SetModifier(ValueStack[ValueStack.Depth-3].modList);ValueStack[ValueStack.Depth-2].mtdDec.SetMethodBody(ValueStack[ValueStack.Depth-1].block); }
#line default
        break;
      case 24: // MethodModifiers -> /* empty */
#line 228 "parser1.y"
                        { CurrentSemanticValue.modList = new System.Collections.Generic.List<AST.Modifier>(); }
#line default
        break;
      case 25: // MethodModifiers -> MethodModifier, MethodModifiers
#line 229 "parser1.y"
                                       { CurrentSemanticValue.modList = ValueStack[ValueStack.Depth-1].modList; ValueStack[ValueStack.Depth-1].modList.Add(ValueStack[ValueStack.Depth-2].mod); }
#line default
        break;
      case 26: // MethodModifier -> PUBLIC
#line 233 "parser1.y"
                     { CurrentSemanticValue.mod = AST.Modifier.Public; }
#line default
        break;
      case 27: // MethodModifier -> STATIC
#line 234 "parser1.y"
                     { CurrentSemanticValue.mod = AST.Modifier.Static; }
#line default
        break;
      case 28: // MethodHeader -> Result, MethodDeclarator, Throws_opt
#line 243 "parser1.y"
                                                                           {CurrentSemanticValue.mtdDec = ValueStack[ValueStack.Depth-2].mtdDec; ValueStack[ValueStack.Depth-2].mtdDec.SetReturnType(ValueStack[ValueStack.Depth-3].typ); }
#line default
        break;
      case 29: // Result -> VOID
#line 247 "parser1.y"
                           {CurrentSemanticValue.typ = new AST.NamedType(ValueStack[ValueStack.Depth-1].keywords);}
#line default
        break;
      case 31: // MethodDeclarator -> IDENTIFIER, '(', ReceiverParameter_opt, 
               //                     FormalParameterList_opt, ')', Dims_opt
#line 259 "parser1.y"
                                                                                   {CurrentSemanticValue.mtdDec = new AST.MethodDeclaration(null, null, ValueStack[ValueStack.Depth-6].name, ValueStack[ValueStack.Depth-3].formalDecList, null);}
#line default
        break;
      case 34: // FormalParameterList_opt -> /* empty */
#line 275 "parser1.y"
                            {CurrentSemanticValue.formalDecList = new System.Collections.Generic.List<AST.FormalParameterDeclaration>();}
#line default
        break;
      case 35: // FormalParameterList_opt -> FormalParameterList
#line 276 "parser1.y"
                                      {CurrentSemanticValue.formalDecList = ValueStack[ValueStack.Depth-1].formalDecList;}
#line default
        break;
      case 36: // FormalParameterList -> FormalParameter
#line 281 "parser1.y"
                                   {CurrentSemanticValue.formalDecList = new System.Collections.Generic.List<AST.FormalParameterDeclaration>(); CurrentSemanticValue.formalDecList.Add(ValueStack[ValueStack.Depth-1].formalDec);}
#line default
        break;
      case 37: // FormalParameter -> VariableModifiers, UnannType, VariableDeclaratorId
#line 287 "parser1.y"
                                                            {CurrentSemanticValue.formalDec = new AST.FormalParameterDeclaration(ValueStack[ValueStack.Depth-2].typ,ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 39: // VariableDeclaratorId -> IDENTIFIER, Dims_opt
#line 295 "parser1.y"
                                     {CurrentSemanticValue.name = ValueStack[ValueStack.Depth-2].name;}
#line default
        break;
      case 40: // UnannType -> UnannReferenceType
#line 299 "parser1.y"
                                  {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 41: // UnannType -> UnannPrimitiveType
#line 300 "parser1.y"
                                  {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 42: // UnannPrimitiveType -> NumericType
#line 304 "parser1.y"
                          {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 43: // NumericType -> IntegralType
#line 308 "parser1.y"
                           {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 44: // IntegralType -> INT
#line 312 "parser1.y"
                    {CurrentSemanticValue.typ = new AST.PrimitiveType(AST.Primitive.Int);}
#line default
        break;
      case 45: // UnannReferenceType -> UnannArrayType
#line 316 "parser1.y"
                            {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 46: // UnannArrayType -> UnannClassOrInterfaceType, Dims
#line 320 "parser1.y"
                                        {CurrentSemanticValue.typ = new AST.ArrayType(ValueStack[ValueStack.Depth-2].typ);}
#line default
        break;
      case 47: // UnannClassOrInterfaceType -> UnannClassType
#line 324 "parser1.y"
                            {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 48: // UnannClassType -> TypeIdentifier, TypeArguments_opt
#line 328 "parser1.y"
                                          {CurrentSemanticValue.typ = new AST.NamedType (ValueStack[ValueStack.Depth-2].name);}
#line default
        break;
      case 53: // MethodBody -> Block
#line 353 "parser1.y"
                   {CurrentSemanticValue.block = ValueStack[ValueStack.Depth-1].block;}
#line default
        break;
      case 54: // Block -> '{', BlockStatements_opt, '}'
#line 357 "parser1.y"
                                   {CurrentSemanticValue.block = new AST.Block(ValueStack[ValueStack.Depth-2].stmtList);}
#line default
        break;
      case 55: // BlockStatements_opt -> BlockStatements
#line 361 "parser1.y"
                          {CurrentSemanticValue.stmtList = ValueStack[ValueStack.Depth-1].stmtList;}
#line default
        break;
      case 56: // BlockStatements -> /* empty */
#line 365 "parser1.y"
                       {CurrentSemanticValue.stmtList = new System.Collections.Generic.List<AST.Statement>(); }
#line default
        break;
      case 57: // BlockStatements -> BlockStatements, BlockStatement
#line 366 "parser1.y"
                                      {CurrentSemanticValue.stmtList = ValueStack[ValueStack.Depth-2].stmtList; ValueStack[ValueStack.Depth-2].stmtList.Add(ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 58: // BlockStatement -> LocalVariableDeclarationStatement
#line 370 "parser1.y"
                                         {CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt;}
#line default
        break;
      case 59: // BlockStatement -> Statement
#line 371 "parser1.y"
                       {CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt;}
#line default
        break;
      case 60: // LocalVariableDeclarationStatement -> LocalVariableDeclaration, ';'
#line 375 "parser1.y"
                                     {CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-2].stmt;}
#line default
        break;
      case 61: // LocalVariableDeclaration -> VariableModifiers, LocalVariableType, 
               //                             VariableDeclaratorList
#line 379 "parser1.y"
                                                              {CurrentSemanticValue.stmt = new AST.VariableDeclarationStatement(ValueStack[ValueStack.Depth-2].typ,ValueStack[ValueStack.Depth-1].declaratorList);}
#line default
        break;
      case 62: // VariableDeclaratorList -> VariableDeclarator, VariableDeclarators
#line 384 "parser1.y"
                                             {CurrentSemanticValue.declaratorList = ValueStack[ValueStack.Depth-1].declaratorList; ValueStack[ValueStack.Depth-1].declaratorList.Add(ValueStack[ValueStack.Depth-2].declarator);}
#line default
        break;
      case 63: // VariableDeclarators -> /* empty */
#line 388 "parser1.y"
                        {CurrentSemanticValue.declaratorList = new System.Collections.Generic.List<AST.VariableDeclarator>(); }
#line default
        break;
      case 64: // VariableDeclarator -> VariableDeclaratorId, VariableInitializer_opt
#line 392 "parser1.y"
                                                  {CurrentSemanticValue.declarator = new AST.VariableDeclarator(ValueStack[ValueStack.Depth-2].name,ValueStack[ValueStack.Depth-1].expr);}
#line default
        break;
      case 66: // LocalVariableType -> UnannType
#line 406 "parser1.y"
                        {CurrentSemanticValue.typ = ValueStack[ValueStack.Depth-1].typ;}
#line default
        break;
      case 67: // Statement -> StatementWithoutTrailingSubstatement
#line 414 "parser1.y"
                                           {CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt;}
#line default
        break;
      case 68: // StatementWithoutTrailingSubstatement -> ExpressionStatement
#line 418 "parser1.y"
                              {CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt;}
#line default
        break;
      case 69: // ExpressionStatement -> StatementExpression, ';'
#line 422 "parser1.y"
                                 {CurrentSemanticValue.stmt = new AST.ExpressionStatement(ValueStack[ValueStack.Depth-2].expr);}
#line default
        break;
      case 70: // StatementExpression -> Assignment
#line 427 "parser1.y"
                       {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 71: // Assignment -> LeftHandSide, AssignmentOperator, Expression
#line 431 "parser1.y"
                                               {CurrentSemanticValue.expr = new AST.AssignmentExpression(ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-2].name, ValueStack[ValueStack.Depth-1].expr);}
#line default
        break;
      case 72: // LeftHandSide -> ExpressionName
#line 435 "parser1.y"
                          {CurrentSemanticValue.expr = new AST.IdentifierExpression(ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 73: // ExpressionName -> IDENTIFIER
#line 443 "parser1.y"
                        {CurrentSemanticValue.name = ValueStack[ValueStack.Depth-1].name;}
#line default
        break;
      case 74: // AssignmentOperator -> '='
#line 447 "parser1.y"
                   {CurrentSemanticValue.name = "=";}
#line default
        break;
      case 75: // Expression -> AssignmentExpression
#line 451 "parser1.y"
                                {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 76: // AssignmentExpression -> ConditionalExpression
#line 455 "parser1.y"
                                 {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 77: // ConditionalExpression -> ConditionalOrExpression
#line 459 "parser1.y"
                                 {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 78: // ConditionalOrExpression -> ConditionalAndExpression
#line 463 "parser1.y"
                                  {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 79: // ConditionalAndExpression -> InclusiveOrExpression
#line 467 "parser1.y"
                                {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 80: // InclusiveOrExpression -> ExclusiveOrExpression
#line 471 "parser1.y"
                                {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 81: // ExclusiveOrExpression -> AndExpression
#line 475 "parser1.y"
                          {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 82: // AndExpression -> EqualityExpression
#line 479 "parser1.y"
                              {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 83: // EqualityExpression -> RelationalExpression
#line 483 "parser1.y"
                               {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 84: // RelationalExpression -> ShiftExpression
#line 492 "parser1.y"
                     {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 85: // ShiftExpression -> AdditiveExpression
#line 496 "parser1.y"
                        {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 86: // AdditiveExpression -> MultiplicativeExpression
#line 500 "parser1.y"
                            {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 87: // MultiplicativeExpression -> UnaryExpression
#line 504 "parser1.y"
                     {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 88: // UnaryExpression -> UnaryExpressionNotPlusMinus
#line 508 "parser1.y"
                              {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 89: // UnaryExpressionNotPlusMinus -> PostfixExpression
#line 512 "parser1.y"
                       {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 90: // PostfixExpression -> Primary
#line 516 "parser1.y"
               {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 91: // Primary -> PrimaryNoNewArray
#line 520 "parser1.y"
                       {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 92: // PrimaryNoNewArray -> Literal
#line 524 "parser1.y"
               {CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr;}
#line default
        break;
      case 93: // Literal -> INT_LITERAL
#line 528 "parser1.y"
                   {CurrentSemanticValue.expr = new AST.IntegerLiteralExpression(ValueStack[ValueStack.Depth-1].Int_Literal);}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 533 "parser1.y"
public AST.Node Root { get; set; }

public Parser(Scanner scanner) : base(scanner)
{
}
#line default
}
}
