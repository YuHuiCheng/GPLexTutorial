%namespace GPLexTutorial

%{
	public static AST.CompilationUnit program;
%}

%union
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
	public string Dec_Int_Literal;
	public string Bin_Int_Literal;
	public string Oct_Int_Literal;
	public string Hex_Int_Literal;
	public string Dec_FPL;
	public string Hex_FPL;

	public AST.CompilationUnit comp;
	public AST.PackageDeclaration packd;
	public AST.ImportDeclaration impd;
	public AST.TypeDeclaration typed;
	public System.Collections.Generic.List<AST.TypeDeclaration> typeds;
	public AST.ClassDeclaration cdec;
	public AST.ClassModifier cmod;
	public System.Collections.Generic.List<AST.ClassModifier> cmods;
	public string ident;
	public System.Collections.Generic.List<AST.ClassBodyDeclaration> clb;
	public AST.ClassBodyDeclaration clbdec;
	public AST.MethodDeclaration mtdec;
	public AST.MethodDeclarator mtdecr;
	public AST.MethodHeader mh;
	public AST.MethodModifier mmod;
	public System.Collections.Generic.List<AST.MethodModifier> mmods;
	public AST.MethodBody mb;
	public AST.Type rt;
	public AST.FormalParameter fp;
	public System.Collections.Generic.List<AST.FormalParameter> fpl;
	public AST.Type ut;
	public AST.ArrayType uat;
	public System.Collections.Generic.List<AST.Statement> bk;
	public AST.Statement bkst;
	public AST.LocalVariableDeclarationStatement lvds;
	public AST.ExpressionStatement st;
	public AST.AssignmentExpression aexpr;
	public AST.Expression expr;
}




%token <num> NUMBER
%token <name> IDENTIFIER
%token <keywords> IF ELSE INT BOOL ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT 
DO DOUBLE ENUM EXTENDS FINAL FINALLY FLOAT FOR GOTO IMPLEMENTS IMPORT INSTANCEOF INTERFACE LONG NATIVE 
NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW 
THROWS TRANSIENT TRY VOID VOLATILE WHILE _
%token <stri> STRINGL
%token <operato> OPERATOR
%token <assignment> ASSIGNMENT
%token <separator> SEPARATOR
%token <character> CHARACTERL
%token <Boolean_Literal> TRUE FALSE
%token <Null_literal> NULL
%token <Dec_Int_Literal> DEC_INT_LITERAL
%token <Bin_Int_Literal> BIN_INT_LITERAL
%token <Oct_Int_Literal> OCT_INT_LITERAL
%token <Hex_Int_Literal> HEX_INT_LITERAL
%token <Dec_FPL> DEC_FPL
%token <Hex_FPL> HEX_FPL

%type <comp>	CompilationUnit
%type <comp>	OrdinaryCompilationUnit
%type <packd>	PackageDeclaration_opt
%type <impd>	ImportDeclaration
%type <typed>	TypeDeclaration
%type <typeds>	TypeDeclarations
%type <cdec>	ClassDeclaration
%type <cdec>	NormalClassDeclaration
%type <cmod>	ClassModifier
%type <cmods>	ClassModifiers
%type <ident>	TypeIdentifier
%type <clb>		ClassBody
%type <clb>		ClassBodyDeclarations
%type <clbdec>	ClassBodyDeclaration
%type <clbdec>  ClassMemberDeclaration
%type <cdec>	TypeParameters_opt 
%type <cdec>	Superclass_opt 
%type <cdec>	Superinterfaces_opt
%type <mh>		MethodHeader
%type <mtdec>	MethodDeclaration
%type <mtdecr>	MethodDeclarator
%type <mmod>	MethodModifier
%type <mmods>	MethodModifiers 
%type <mb>		MethodBody
%type <rt>		ResultType
%type <fp>		FormalParameter
%type <fpl>		FormalParameterList
%type <ident>	VariableDeclaratorId
%type <ut>		UnannType
%type <ut>		UnannReferenceType
%type <ut>		UnannPrimitiveType
%type <ut>		NumericType
%type <ut>		IntegralType	
%type <uat>		UnannArrayType
%type <uat>		UnannClassOrInterfaceType
%type <uat>		UnannClassType
%type <bk>		Block
%type <bk>		BlockStatements_opt
%type <bk>		BlockStatements
%type <bkst>	BlockStatement
%type <lvds>	LocalVariableDeclarationStatement	
%type <st>		Statement	
%type <lvds>	LocalVariableDeclaration
%type <lvds>	VariableModifiers 
%type <ut>		LocalVariableType 
%type <ident>	VariableDeclaratorList
%type <st>		StatementWithoutTrailingSubstatement
%type <st>		ExpressionStatement
%type <st>		StatementExpression
%type <aexpr>	Assignment
%type <ident>	LeftHandSide 
%type <ident>	AssignmentOperator 
%type <expr>	Expression
%type <ident>	ExpressionName
%type <expr>	AssignmentExpression
%type <expr>	ConditionalExpression
%type <expr>	ConditionalOrExpression
%type <expr>	ConditionalAndExpression
%type <expr>	InclusiveOrExpression
%type <expr>	ExclusiveOrExpression
%type <expr>	AndExpression
%type <expr>	EqualityExpression
%type <expr>	RelationalExpression
%type <expr>	ShiftExpression
%type <expr>	AdditiveExpression
%type <expr>	MultiplicativeExpression
%type <expr>	UnaryExpression
%type <expr>	UnaryExpressionNotPlusMinus
%type <expr>	PostfixExpression
%type <expr>	Primary
%type <expr>	PrimaryNoNewArray
%type <expr>	Literal


%%

Program 
	: CompilationUnit																				{program = $1;}
    ;

CompilationUnit																						
	: OrdinaryCompilationUnit																		{$$ = $1;}	
	;

OrdinaryCompilationUnit																	
	: PackageDeclaration_opt ImportDeclaration TypeDeclarations										{$$ = new AST.CompilationUnit($1,$2,$3);}
	;

PackageDeclaration_opt
	: /*empty*/																						{$$ = new AST.PackageDeclaration();}	
	;

ImportDeclaration
	: /*empty*/																						{$$ = new AST.ImportDeclaration();}  
	;

TypeDeclarations
	: /*empty*/																						{$$ = new System.Collections.Generic.List<AST.TypeDeclaration>();}
	| TypeDeclarations TypeDeclaration															    {$$ = $1; $1.Add($2);}
	;  

TypeDeclaration
	: ClassDeclaration																				{$$ = $1;}
	;

ClassDeclaration
	: NormalClassDeclaration																		{$$ = $1;}
	;


/*NormalClassDeclaration*/

NormalClassDeclaration
	: ClassModifiers CLASS TypeIdentifier TypeParameters_opt Superclass_opt Superinterfaces_opt ClassBody		{$$ = new AST.ClassDeclaration($1,$3,$7);}
 	;

ClassModifiers
	: /*empty*/																						{$$ = new System.Collections.Generic.List<AST.ClassModifier>();}
	| ClassModifiers ClassModifier																	{$$ = $1; $1.Add($2);}
	;

ClassModifier
	: PUBLIC																						{$$ = AST.ClassModifier.Public;}	
	;

TypeIdentifier
	: IDENTIFIER																					
	;

TypeParameters_opt
	: /*empty*/																								
	;

Superclass_opt
	: /*empty*/
	;

Superinterfaces_opt
	: /*empty*/
	;




/*ClassBody*/

ClassBody
	: '{' ClassBodyDeclarations '}'																	{$$ = $2;}
    ;

ClassBodyDeclarations
    : /*empty*/																						{$$ = new System.Collections.Generic.List<AST.ClassBodyDeclaration>();}
    | ClassBodyDeclarations ClassBodyDeclaration													{$$ = $1; $1.Add($2);}	
    ;

ClassBodyDeclaration
    : ClassMemberDeclaration																		{$$ = $1;}
    ;

ClassMemberDeclaration
    : MethodDeclaration																				{$$ = $1;}
    ;



/*MethodDeclaration*/

MethodDeclaration																					
    : MethodModifiers MethodHeader MethodBody														{$$ = new AST.MethodDeclaration($1,$2,$3);}
    ;

MethodModifiers
    : /*empty*/																						{$$ = new System.Collections.Generic.List<AST.MethodModifier>();}
    | MethodModifiers MethodModifier																{$$ = $1; $1.Add($2);}
    ;

MethodModifier
    : PUBLIC																						{$$ = AST.MethodModifier.Public;}
    | STATIC																						{$$ = AST.MethodModifier.Static;}
    ;



/*MethodHeader*/

MethodHeader
    : ResultType MethodDeclarator 																	{$$ = new AST.MethodHeader($1,$2);}	
    ;

ResultType
    : VOID																							{$$ = AST.Type.VOID;}	
    ;



/*MethodDeclarator*/

MethodDeclarator
    : IDENTIFIER '(' ReceiverParameter_opt FormalParameterList ')' Dims_opt							{$$ = new AST.MethodDeclarator($1,$4);}
    ;

ReceiverParameter_opt
    : /*empty*/
    ;

Dims_opt
    : /*empty*/
    ;



/*FormalParameterList_opt*/

FormalParameterList
	: /*empty*/																						{$$ = new System.Collections.Generic.List<AST.FormalParameter>();}
    | FormalParameterList FormalParameter															{$$ = $1; $1.Add($2);}	
    ;


/*FormalParameter*/

/* Type here is uanntype */

FormalParameter
    : VariableModifiers UnannType VariableDeclaratorId												{$$ = new AST.FormalParameter($2,$3);}
    ;

VariableModifiers
    : /*empty*/
    ;

VariableDeclaratorId
    : IDENTIFIER Dims_opt																			
    ;

UnannType																					
    : UnannReferenceType																			{$$ = $1;}		
    | UnannPrimitiveType																			{$$ = $1;}	
    ;

UnannPrimitiveType
    : NumericType																					{$$ = $1;}						
    ;

NumericType
    : IntegralType																					{$$ = $1;}	
    ;

IntegralType
    : INT																							{$$ = AST.Type.INT;}
    ;

UnannReferenceType
	: UnannArrayType																				{$$ = $1;}									
	;

UnannArrayType
    : UnannClassOrInterfaceType Dims																{$$ = $1;}		
    ;

UnannClassOrInterfaceType
    : UnannClassType																				{$$ = new AST.ArrayType($1);}
    ;

UnannClassType
    : TypeIdentifier TypeArguments_opt																
    ;

TypeArguments_opt
    : /*empty*/
    ;

Dims
    : Annotations '[' ']' Annotation_opt
    ;

Annotations
    : /*empty*/
    ;

Annotation_opt
    : /*empty*/
    ;




/*MethodBody*/

MethodBody
    : Block																							{$$ = new AST.MethodBody($1);}
    ;

Block
    : '{' BlockStatements_opt '}'																	{$$ = $2;}
    ;

BlockStatements_opt
    : BlockStatements																				{$$ = $1;}
    ;

BlockStatements
    : /*empty*/																						{$$ = new System.Collections.Generic.List<AST.Statement>();}
    | BlockStatements BlockStatement																{$$ = $1; $1.Add($2);}	
    ;

BlockStatement
    : LocalVariableDeclarationStatement																{$$ = $1;}
    | Statement																						{$$ = $1;}
    ;

LocalVariableDeclarationStatement
    : LocalVariableDeclaration ';'																	{$$ = $1;}
    ;

LocalVariableDeclaration
    : VariableModifiers LocalVariableType VariableDeclaratorList									{$$ = new AST.LocalVariableDeclarationStatement($2,$3);}			
    ;


VariableDeclaratorList
    : IDENTIFIER																					{$$ = $1;}
    ;


/*LocalVariableType*/

LocalVariableType
    : UnannType																						{$$ = $1;}				
    ;

UnannType
	: UnannPrimitiveType																			{$$ = $1;}
	;

UnannPrimitiveType
	: NumericType																					{$$ = $1;}
	;

NumericType
	: IntegralType																					{$$ = $1;}			
	;

IntegralType
	: INT																							{$$ = AST.Type.INT;}
	;




/*BlockStatements*/

Statement
	: StatementWithoutTrailingSubstatement															{$$ = $1;}	
	;

StatementWithoutTrailingSubstatement
	: ExpressionStatement																			{$$ = $1;}	
	;

ExpressionStatement
	: StatementExpression ';'																		{$$ = $1;}	
	;

StatementExpression
	: Assignment																					{$$ = new AST.ExpressionStatement($1);}		
	;

Assignment
	: LeftHandSide AssignmentOperator Expression													{$$ = new AST.AssignmentExpression($1,$2,$3);}
	;

LeftHandSide
	: ExpressionName																				{$$ = $1;}										
	;

ExpressionName
	: IDENTIFIER																					{$$ = $1;}
	;

AssignmentOperator 
	: '='																							
	;

Expression
	: AssignmentExpression																			{$$ = $1;}													
	;

AssignmentExpression
	: ConditionalExpression																			{$$ = $1;}
	;

ConditionalExpression
	:ConditionalOrExpression																		{$$ = $1;}
	;

ConditionalOrExpression
	:ConditionalAndExpression																		{$$ = $1;}
	;

ConditionalAndExpression
	:InclusiveOrExpression																			{$$ = $1;}
	;

InclusiveOrExpression
	:ExclusiveOrExpression																			{$$ = $1;}
	;

ExclusiveOrExpression
	:AndExpression																					{$$ = $1;}
	;

AndExpression
	:EqualityExpression																				{$$ = $1;}
	;

EqualityExpression
	:RelationalExpression																			{$$ = $1;}			
	;

RelationalExpression
	:ShiftExpression																				{$$ = $1;}	
	;

ShiftExpression
	:AdditiveExpression																				{$$ = $1;}
	;

AdditiveExpression
	:MultiplicativeExpression																		{$$ = $1;}
	;

MultiplicativeExpression
	:UnaryExpression																				{$$ = $1;}
	;

UnaryExpression
	:UnaryExpressionNotPlusMinus																	{$$ = $1;}
	;

UnaryExpressionNotPlusMinus
	:PostfixExpression																				{$$ = $1;}
	;

PostfixExpression
	:Primary																						{$$ = $1;}
	;

Primary
	:PrimaryNoNewArray																				{$$ = $1;}
	;

PrimaryNoNewArray
	:Literal																						{$$ = $1;}
	;

Literal
	: DEC_INT_LITERAL																				{$$ = new AST.IntExpression($1);}
	;

%%
public Parser(Scanner scanner) : base(scanner)
{
}




