%namespace GPLexTutorial

%{
int lines = 0;
%}


digit [0-9]
letter [a-zA-Z]
Underscores _*_+																	
IntegerTypeSuffix		[1L]														

/*DecimalIntegerLiteral*/
ZeroToThree							[0-3]
NonZeroDigit						[1-9]
DigitOrUnderscore 					{digit}|\_
DigitsAndUnderscores				{DigitOrUnderscore}{DigitOrUnderscore}*
Digits								{digit}|{digit}{DigitsAndUnderscores}{digit}
DecimalNumeral						[0]|{NonZeroDigit}{Digits}?|{NonZeroDigit}{Underscores}{Digits}
DecimalIntegerLiteral				{DecimalNumeral}{IntegerTypeSuffix}?


/*OctalIntegerLiteral*/

OctalDigit							[0-7]
OctalEscape							{ZeroToThree}{OctalDigit}{OctalDigit}
EscapeSequence						\\([btnfr"'\\]|{OctalEscape})
OctalDigits							({OctalDigit}?|{OctalDigit}{Underscores}{OctalDigit})
OctalNumeral						(0{OctalDigits}|{Underscores}{OctalDigit})
OctalIntegerLiteral					{OctalNumeral}{IntegerTypeSuffix}?	


/*HexIntegerLiteral*/

HexDigit							[0-9a-fA-F]
HexDigitOrUnderscore				{HexDigit}|\_	
HexDigitsAndUnderscores				{HexDigitOrUnderscore}+	
HexDigits							{HexDigit}|{HexDigit}{HexDigitsAndUnderscores}?{HexDigit}
HexNumeral							[0][X]{HexDigits}|[0][x]{HexDigits}												
HexIntegerLiteral					{HexNumeral}{IntegerTypeSuffix}?


/*BinaryIntegerLiteral*/ 

BinaryDigit							[^2-9]
BinaryDigitOrUnderscore				{BinaryDigit}|\_
BinaryDigitsAndUnderscores			{BinaryDigitOrUnderscore}{BinaryDigitOrUnderscore}*
BinaryDigits						{BinaryDigit}|{BinaryDigit}{Underscores}{BinaryDigit}
BinaryNumeral						[0][B]{BinaryDigits}|[0][b]{BinaryDigits}
BinaryIntegerLiteral				{BinaryNumeral}{IntegerTypeSuffix}?


/*Hexadecimal Floating Point Literal*/
Sign								[\+\-]
BinaryExponentIndicator				[pP]
SignedInteger						{Sign}{Digits}
FloatTypeSuffix						[fFdD]	
HexSignificand						{HexNumeral}[\.]|[0][x]{HexDigits}[\.]{HexDigits}|[0][X]{HexDigits}[\.]{HexDigits}
BinaryExponent						{BinaryExponentIndicator}{SignedInteger}
HexadecimalFloatingPointLiteral		{HexSignificand}{BinaryExponent}{FloatTypeSuffix}

/*Decimal Floating Point Literal*/
ExponentIndicator					[eE]
ExponentPart						{ExponentIndicator}{SignedInteger}
DecimalFloatingPointLiteral			{Digits}[\.]{Digits}{ExponentPart}{FloatTypeSuffix}|[\.]{Digits}{ExponentPart}{FloatTypeSuffix}|{Digits}{ExponentPart}{FloatTypeSuffix}|{Digits}{ExponentPart}{FloatTypeSuffix}



/*Charactor Literals*/

UnicodeMarker						uu*
UnicodeEscape						uu*
RawInputCharacter					uu*
UnicodeInputCharacter				{UnicodeEscape}*|{RawInputCharacter}*
InputCharacter						{UnicodeInputCharacter}
SingleCharacter						{InputCharacter}
CharacterLiteral					\'[SingleCharacter]\'|\'[EscapeSequence]\'



/*String Literals*/

StringCharacter						{InputCharacter}*|{EscapeSequence}*
StringLiteral						\"{StringCharacter}\"

BooleanLiteral						(true|false)



%%


/*Keywords*/

public								{ yylval.keywords = yytext; return (int)Tokens.PUBLIC; }
class								{ yylval.keywords = yytext; return (int)Tokens.CLASS; }
static								{ yylval.keywords = yytext; return (int)Tokens.STATIC; }
void								{ yylval.keywords = yytext; return (int)Tokens.VOID; }
int 								{ yylval.keywords = yytext; return (int)Tokens.INT;  }
do									{ yylval.keywords = yytext; return (int)Tokens.DO;  }
while								{ yylval.keywords = yytext; return (int)Tokens.WHILE; }
enum								{ yylval.keywords = yytext; return (int)Tokens.ENUM; }
char								{ yylval.keywords = yytext; return (int)Tokens.CHAR; }
for									{ yylval.keywords = yytext; return (int)Tokens.FOR; }
new									{ yylval.keywords = yytext; return (int)Tokens.NEW; }
double								{ yylval.keywords = yytext; return (int)Tokens.DOUBLE; }
if									{ yylval.keywords = yytext; return (int)Tokens.IF; }
else								{ yylval.keywords = yytext; return (int)Tokens.ELSE; }
super								{ yylval.keywords = yytext; return (int)Tokens.SUPER; }
this								{ yylval.keywords = yytext; return (int)Tokens.THIS; }
break								{ yylval.keywords = yytext; return (int)Tokens.BREAK; }
import								{ yylval.keywords = yytext; return (int)Tokens.IMPORT; }
abstract							{ yylval.keywords = yytext; return (int)Tokens.ABSTRACT; }
assert								{ yylval.keywords = yytext; return (int)Tokens.ASSERT; }
boolean								{ yylval.keywords = yytext; return (int)Tokens.BOOLEAN; }
byte								{ yylval.keywords = yytext; return (int)Tokens.BYTE; }
case								{ yylval.keywords = yytext; return (int)Tokens.CASE; }
const								{ yylval.keywords = yytext; return (int)Tokens.CONST; }
continue							{ yylval.keywords = yytext; return (int)Tokens.CONTINUE; }
default								{ yylval.keywords = yytext; return (int)Tokens.DEFAULT; }
extends								{ yylval.keywords = yytext; return (int)Tokens.EXTENDS; }
final								{ yylval.keywords = yytext; return (int)Tokens.FINAL; }
finally								{ yylval.keywords = yytext; return (int)Tokens.FINALLY; }
float								{ yylval.keywords = yytext; return (int)Tokens.FLOAT; }
goto								{ yylval.keywords = yytext; return (int)Tokens.GOTO; }
implements							{ yylval.keywords = yytext; return (int)Tokens.IMPLEMENTS; }
instanceof							{ yylval.keywords = yytext; return (int)Tokens.INSTANCEOF; }
interface							{ yylval.keywords = yytext; return (int)Tokens.INTERFACE; }
long								{ yylval.keywords = yytext; return (int)Tokens.LONG; }
native								{ yylval.keywords = yytext; return (int)Tokens.NATIVE; }
private								{ yylval.keywords = yytext; return (int)Tokens.PRIVATE; }
protected							{ yylval.keywords = yytext; return (int)Tokens.PROTECTED; }
short								{ yylval.keywords = yytext; return (int)Tokens.SHORT; }
strictfp							{ yylval.keywords = yytext; return (int)Tokens.STRICTFP; }
synchronized						{ yylval.keywords = yytext; return (int)Tokens.SYNCHRONIZED; }
throw								{ yylval.keywords = yytext; return (int)Tokens.THROW; }
transient							{ yylval.keywords = yytext; return (int)Tokens.TRANSIENT; }
try									{ yylval.keywords = yytext; return (int)Tokens.TRY; }
volatile							{ yylval.keywords = yytext; return (int)Tokens.VOLATILE; }





/*Interger Literals*/

{HexIntegerLiteral}					{ yylval.Hex_Int_Literal = yytext; return (int)Tokens.HEX_INT_LITERAL;}													//The value added by Dambar Thapa 08/03/19
{BinaryIntegerLiteral}				{ yylval.Bin_Int_Literal = yytext; return (int)Tokens.BIN_INT_LITERAL; }												//The value is added by Chao Jiang 07/03/19
{OctalIntegerLiteral}				{ yylval.Oct_Int_Literal = yytext; return (int)Tokens.OCT_INT_LITERAL; }
{DecimalIntegerLiteral}				{ yylval.Dec_Int_Literal = yytext; return (int)Tokens.DEC_INT_LITERAL;}


/*String Literals*/

{StringLiteral}						{ yylval.stri = yytext; return (int)Tokens.STRINGL; }


/*Character Literals*/

{CharacterLiteral}					{ yylval.character = yytext; return (int)Tokens.CHARACTERL; }


/*Null Literal*/

null								{ yylval.Null_literal = yytext; return (int)Tokens.NULL; }


/*Boolean Literal*/

true								{ yylval.Boolean_Literal = yytext; return (int)Tokens.TRUE; }
false								{ yylval.Boolean_Literal = yytext; return (int)Tokens.FALSE; }




/*Floating Point Literal*/

{HexadecimalFloatingPointLiteral}	 { yylval.Hex_FPL = yytext; return (int)Tokens.HEX_FPL; }
{DecimalFloatingPointLiteral}		 { yylval.Dec_FPL = yytext; return (int)Tokens.DEC_FPL; }





/*Operator*/

">>"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"&&"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"||"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }									//Added by Cheng YuHui
"?:"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"++"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"-"									{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"<<"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
">>>"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"^"									{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"=="								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"!="								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"->"								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
">="								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"<="								{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
">"									{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }
"<"									{ yylval.operato = yytext; return (int)Tokens.OPERATOR; }



/*Assignment*/

">>="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"&&="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"%="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"*="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"&="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"||="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }
"-="								{ yylval.assignment = yytext; return (int)Tokens.ASSIGNMENT; }



/*Separator*/

"."									{ return '.'; }									
"%"									{ return '%'; }															//The value added by Dambar Thapa 08/03/19
"=" 								{ return '='; }
"(" 								{ return '('; }
")" 								{ return ')'; }
"{" 								{ return '{'; }
"}" 								{ return '}'; }
";" 								{ return ';'; }
"," 								{ return ','; }
"["									{ return '['; }
"]"									{ return ']'; }
"*"									{ return '*'; }





{letter}({letter}|{digit})*			{ return (int)Tokens.IDENTIFIER; }
{digit}+                     		{ return (int)Tokens.NUMBER; }





[\n]								{ lines++;    }
[ \t\r]								/* ignore other whitespace */



.     								{ 
										throw new Exception(
											String.Format(
												"unexpected character '{0}'", yytext)); 
									}



%%
public override void yyerror( string format, params object[] args )
{
    System.Console.Error.WriteLine("Error: line {0}, {1}", lines,
        String.Format(format, args));
}
