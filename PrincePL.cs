
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF             =  0, // (EOF)
        SYMBOL_ERROR           =  1, // (Error)
        SYMBOL_WHITESPACE      =  2, // Whitespace
        SYMBOL_MINUS           =  3, // '-'
        SYMBOL_MINUSMINUS      =  4, // '--'
        SYMBOL_EXCLAMEQ        =  5, // '!='
        SYMBOL_PERCENT         =  6, // '%'
        SYMBOL_PERCENTEQ       =  7, // '%='
        SYMBOL_AMP             =  8, // '&'
        SYMBOL_AMPAMP          =  9, // '&&'
        SYMBOL_AMPEQ           = 10, // '&='
        SYMBOL_LPAREN          = 11, // '('
        SYMBOL_RPAREN          = 12, // ')'
        SYMBOL_TIMES           = 13, // '*'
        SYMBOL_TIMESEQ         = 14, // '*='
        SYMBOL_COMMA           = 15, // ','
        SYMBOL_DIV             = 16, // '/'
        SYMBOL_DIVEQ           = 17, // '/='
        SYMBOL_COLON           = 18, // ':'
        SYMBOL_SEMI            = 19, // ';'
        SYMBOL_QUESTION        = 20, // '?'
        SYMBOL_LBRACKET        = 21, // '['
        SYMBOL_RBRACKET        = 22, // ']'
        SYMBOL_CARET           = 23, // '^'
        SYMBOL_CARETEQ         = 24, // '^='
        SYMBOL_LBRACE          = 25, // '{'
        SYMBOL_PIPE            = 26, // '|'
        SYMBOL_PIPEPIPE        = 27, // '||'
        SYMBOL_PIPEEQ          = 28, // '|='
        SYMBOL_RBRACE          = 29, // '}'
        SYMBOL_PLUS            = 30, // '+'
        SYMBOL_PLUSPLUS        = 31, // '++'
        SYMBOL_PLUSEQ          = 32, // '+='
        SYMBOL_LT              = 33, // '<'
        SYMBOL_LTLT            = 34, // '<<'
        SYMBOL_LTLTEQ          = 35, // '<<='
        SYMBOL_LTEQ            = 36, // '<='
        SYMBOL_EQ              = 37, // '='
        SYMBOL_MINUSEQ         = 38, // '-='
        SYMBOL_EQEQ            = 39, // '=='
        SYMBOL_GT              = 40, // '>'
        SYMBOL_GTEQ            = 41, // '>='
        SYMBOL_GTGT            = 42, // '>>'
        SYMBOL_GTGTEQ          = 43, // '>>='
        SYMBOL_CHARLITERAL     = 44, // CharLiteral
        SYMBOL_CLASS           = 45, // class
        SYMBOL_ELSE            = 46, // else
        SYMBOL_FALSE           = 47, // false
        SYMBOL_FOR             = 48, // for
        SYMBOL_FUNCTION        = 49, // function
        SYMBOL_IDENTIFIER      = 50, // Identifier
        SYMBOL_IF              = 51, // if
        SYMBOL_NULL            = 52, // null
        SYMBOL_NUMBERS         = 53, // Numbers
        SYMBOL_RETURN          = 54, // return
        SYMBOL_STRINGLITERAL   = 55, // StringLiteral
        SYMBOL_TRUE            = 56, // true
        SYMBOL_WHILE           = 57, // while
        SYMBOL_ADDEXP          = 58, // <Add Exp>
        SYMBOL_ANDEXP          = 59, // <And Exp>
        SYMBOL_ARGUMENTLIST    = 60, // <Argument List>
        SYMBOL_ARRAY           = 61, // <Array>
        SYMBOL_ASSIGNMENT      = 62, // <Assignment>
        SYMBOL_ASSIGNMENTLIST  = 63, // <Assignment List>
        SYMBOL_BLOCK           = 64, // <Block>
        SYMBOL_CLASS2          = 65, // <Class>
        SYMBOL_CLASSLIST       = 66, // <Class List>
        SYMBOL_COMPAREEXP      = 67, // <Compare Exp>
        SYMBOL_ELEMENTS        = 68, // <elements>
        SYMBOL_EQUALITYEXP     = 69, // <Equality Exp>
        SYMBOL_EXPR            = 70, // <Expr>
        SYMBOL_EXPRESSION      = 71, // <Expression>
        SYMBOL_FORLOOP         = 72, // <for loop>
        SYMBOL_FUNCTIONCALL    = 73, // <Function Call>
        SYMBOL_FUNCTIONDECL    = 74, // <Function Decl>
        SYMBOL_IFSTATMENT      = 75, // <if statment>
        SYMBOL_INDEX           = 76, // <index>
        SYMBOL_INLINECONDITION = 77, // <inline condition>
        SYMBOL_LITERAL         = 78, // <Literal>
        SYMBOL_LOGICALANDEXP   = 79, // <Logical And Exp>
        SYMBOL_LOGICALOREXP    = 80, // <Logical Or Exp>
        SYMBOL_LOGICALXOREXP   = 81, // <Logical Xor Exp>
        SYMBOL_MULTEXP         = 82, // <Mult Exp>
        SYMBOL_OREXP           = 83, // <Or Exp>
        SYMBOL_PARAMETERS      = 84, // <Parameters>
        SYMBOL_POSTFIXEXP      = 85, // <Postfix Exp>
        SYMBOL_PREFIXEXP       = 86, // <Prefix Exp>
        SYMBOL_PROGRAM         = 87, // <Program>
        SYMBOL_SHIFTEXP        = 88, // <Shift Exp>
        SYMBOL_STATMENT        = 89, // <Statment>
        SYMBOL_STATMENTLIST    = 90, // <Statment List>
        SYMBOL_UNARYEXP        = 91, // <Unary Exp>
        SYMBOL_WHILELOOP       = 92  // <while loop>
    };

    enum RuleConstants : int
    {
        RULE_LITERAL_TRUE                                                             =  0, // <Literal> ::= true
        RULE_LITERAL_FALSE                                                            =  1, // <Literal> ::= false
        RULE_LITERAL_NUMBERS                                                          =  2, // <Literal> ::= Numbers
        RULE_LITERAL_CHARLITERAL                                                      =  3, // <Literal> ::= CharLiteral
        RULE_LITERAL_STRINGLITERAL                                                    =  4, // <Literal> ::= StringLiteral
        RULE_LITERAL_NULL                                                             =  5, // <Literal> ::= null
        RULE_PROGRAM                                                                  =  6, // <Program> ::= <Class List>
        RULE_CLASSLIST                                                                =  7, // <Class List> ::= <Class List> <Class>
        RULE_CLASSLIST2                                                               =  8, // <Class List> ::= <Class>
        RULE_CLASS_CLASS_IDENTIFIER                                                   =  9, // <Class> ::= class Identifier <Block>
        RULE_FUNCTIONDECL_FUNCTION_IDENTIFIER_LPAREN_RPAREN                           = 10, // <Function Decl> ::= function Identifier '(' <Parameters> ')' <Block>
        RULE_FUNCTIONDECL_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RETURN_SEMI_RBRACE = 11, // <Function Decl> ::= function Identifier '(' <Parameters> ')' '{' <Statment List> return <Expression> ';' '}'
        RULE_PARAMETERS_IDENTIFIER_COMMA                                              = 12, // <Parameters> ::= Identifier ',' <Parameters>
        RULE_PARAMETERS_IDENTIFIER                                                    = 13, // <Parameters> ::= Identifier
        RULE_PARAMETERS                                                               = 14, // <Parameters> ::= 
        RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN                                    = 15, // <Function Call> ::= Identifier '(' <Argument List> ')'
        RULE_ARGUMENTLIST_COMMA                                                       = 16, // <Argument List> ::= <Expression> ',' <Argument List>
        RULE_ARGUMENTLIST                                                             = 17, // <Argument List> ::= <Expression>
        RULE_ARGUMENTLIST2                                                            = 18, // <Argument List> ::= 
        RULE_STATMENTLIST                                                             = 19, // <Statment List> ::= <Statment List> <Statment>
        RULE_STATMENTLIST2                                                            = 20, // <Statment List> ::= <Statment>
        RULE_STATMENT                                                                 = 21, // <Statment> ::= <Assignment List>
        RULE_STATMENT_SEMI                                                            = 22, // <Statment> ::= <Expression> ';'
        RULE_STATMENT2                                                                = 23, // <Statment> ::= <if statment>
        RULE_STATMENT3                                                                = 24, // <Statment> ::= <inline condition>
        RULE_STATMENT4                                                                = 25, // <Statment> ::= <for loop>
        RULE_STATMENT5                                                                = 26, // <Statment> ::= <while loop>
        RULE_STATMENT6                                                                = 27, // <Statment> ::= <Function Decl>
        RULE_STATMENT_SEMI2                                                           = 28, // <Statment> ::= <Function Call> ';'
        RULE_BLOCK_LBRACE_RBRACE                                                      = 29, // <Block> ::= '{' <Statment List> '}'
        RULE_BLOCK_LBRACE_RBRACE2                                                     = 30, // <Block> ::= '{' '}'
        RULE_ASSIGNMENTLIST_COMMA_SEMI                                                = 31, // <Assignment List> ::= <Assignment List> ',' <Assignment> ';'
        RULE_ASSIGNMENTLIST_SEMI                                                      = 32, // <Assignment List> ::= <Assignment> ';'
        RULE_ASSIGNMENT_IDENTIFIER_EQ                                                 = 33, // <Assignment> ::= Identifier '=' <Expression>
        RULE_IFSTATMENT_IF                                                            = 34, // <if statment> ::= if <Expression> <Block>
        RULE_IFSTATMENT_IF_ELSE                                                       = 35, // <if statment> ::= if <Expression> <Block> else <Block>
        RULE_INLINECONDITION_QUESTION_COLON_SEMI                                      = 36, // <inline condition> ::= <Expression> '?' <Expression> ':' <Expression> ';'
        RULE_ARRAY_LBRACKET_RBRACKET                                                  = 37, // <Array> ::= '[' <elements> ']'
        RULE_ELEMENTS                                                                 = 38, // <elements> ::= <Literal>
        RULE_ELEMENTS_COMMA                                                           = 39, // <elements> ::= <Literal> ',' <elements>
        RULE_INDEX_IDENTIFIER_LBRACKET_NUMBERS_RBRACKET                               = 40, // <index> ::= Identifier '[' Numbers ']'
        RULE_INDEX_IDENTIFIER_LBRACKET_IDENTIFIER_RBRACKET                            = 41, // <index> ::= Identifier '[' Identifier ']'
        RULE_FORLOOP_FOR_LPAREN_SEMI_RPAREN                                           = 42, // <for loop> ::= for '(' <Assignment List> <Expression> ';' <Expression> ')' <Block>
        RULE_WHILELOOP_WHILE_LPAREN_RPAREN                                            = 43, // <while loop> ::= while '(' <Expression> ')' <Block>
        RULE_EXPRESSION_EQ                                                            = 44, // <Expression> ::= <Or Exp> '=' <Expression>
        RULE_EXPRESSION_PLUSEQ                                                        = 45, // <Expression> ::= <Or Exp> '+=' <Expression>
        RULE_EXPRESSION_MINUSEQ                                                       = 46, // <Expression> ::= <Or Exp> '-=' <Expression>
        RULE_EXPRESSION_TIMESEQ                                                       = 47, // <Expression> ::= <Or Exp> '*=' <Expression>
        RULE_EXPRESSION_DIVEQ                                                         = 48, // <Expression> ::= <Or Exp> '/=' <Expression>
        RULE_EXPRESSION_CARETEQ                                                       = 49, // <Expression> ::= <Or Exp> '^=' <Expression>
        RULE_EXPRESSION_AMPEQ                                                         = 50, // <Expression> ::= <Or Exp> '&=' <Expression>
        RULE_EXPRESSION_PIPEEQ                                                        = 51, // <Expression> ::= <Or Exp> '|=' <Expression>
        RULE_EXPRESSION_PERCENTEQ                                                     = 52, // <Expression> ::= <Or Exp> '%=' <Expression>
        RULE_EXPRESSION_LTLTEQ                                                        = 53, // <Expression> ::= <Or Exp> '<<=' <Expression>
        RULE_EXPRESSION_GTGTEQ                                                        = 54, // <Expression> ::= <Or Exp> '>>=' <Expression>
        RULE_EXPRESSION                                                               = 55, // <Expression> ::= <Or Exp>
        RULE_OREXP_PIPEPIPE                                                           = 56, // <Or Exp> ::= <Or Exp> '||' <And Exp>
        RULE_OREXP                                                                    = 57, // <Or Exp> ::= <And Exp>
        RULE_ANDEXP_AMPAMP                                                            = 58, // <And Exp> ::= <And Exp> '&&' <Logical Or Exp>
        RULE_ANDEXP                                                                   = 59, // <And Exp> ::= <Logical Or Exp>
        RULE_LOGICALOREXP_PIPE                                                        = 60, // <Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
        RULE_LOGICALOREXP                                                             = 61, // <Logical Or Exp> ::= <Logical Xor Exp>
        RULE_LOGICALXOREXP_CARET                                                      = 62, // <Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
        RULE_LOGICALXOREXP                                                            = 63, // <Logical Xor Exp> ::= <Logical And Exp>
        RULE_LOGICALANDEXP_AMP                                                        = 64, // <Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
        RULE_LOGICALANDEXP                                                            = 65, // <Logical And Exp> ::= <Equality Exp>
        RULE_EQUALITYEXP_EQEQ                                                         = 66, // <Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
        RULE_EQUALITYEXP_EXCLAMEQ                                                     = 67, // <Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
        RULE_EQUALITYEXP                                                              = 68, // <Equality Exp> ::= <Compare Exp>
        RULE_COMPAREEXP_LT                                                            = 69, // <Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
        RULE_COMPAREEXP_GT                                                            = 70, // <Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
        RULE_COMPAREEXP_LTEQ                                                          = 71, // <Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
        RULE_COMPAREEXP_GTEQ                                                          = 72, // <Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
        RULE_COMPAREEXP                                                               = 73, // <Compare Exp> ::= <Shift Exp>
        RULE_SHIFTEXP_LTLT                                                            = 74, // <Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
        RULE_SHIFTEXP_GTGT                                                            = 75, // <Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
        RULE_SHIFTEXP                                                                 = 76, // <Shift Exp> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                              = 77, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                             = 78, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                                   = 79, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                            = 80, // <Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
        RULE_MULTEXP_DIV                                                              = 81, // <Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
        RULE_MULTEXP_PERCENT                                                          = 82, // <Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
        RULE_MULTEXP                                                                  = 83, // <Mult Exp> ::= <Unary Exp>
        RULE_UNARYEXP                                                                 = 84, // <Unary Exp> ::= <Postfix Exp>
        RULE_UNARYEXP2                                                                = 85, // <Unary Exp> ::= <Prefix Exp>
        RULE_UNARYEXP3                                                                = 86, // <Unary Exp> ::= <Expr>
        RULE_POSTFIXEXP_PLUSPLUS                                                      = 87, // <Postfix Exp> ::= <Expr> '++'
        RULE_POSTFIXEXP_MINUSMINUS                                                    = 88, // <Postfix Exp> ::= <Expr> '--'
        RULE_PREFIXEXP_PLUSPLUS                                                       = 89, // <Prefix Exp> ::= '++' <Expr>
        RULE_PREFIXEXP_MINUSMINUS                                                     = 90, // <Prefix Exp> ::= '--' <Expr>
        RULE_EXPR_LPAREN_RPAREN                                                       = 91, // <Expr> ::= '(' <Expression> ')'
        RULE_EXPR                                                                     = 92, // <Expr> ::= <Literal>
        RULE_EXPR2                                                                    = 93, // <Expr> ::= <Array>
        RULE_EXPR_IDENTIFIER                                                          = 94, // <Expr> ::= Identifier
        RULE_EXPR3                                                                    = 95, // <Expr> ::= <Function Call>
        RULE_EXPR4                                                                    = 96  // <Expr> ::= <index>
    };

    public class MyParser
    {
        private LALRParser parser;
        RichTextBox Rtb_code;
        RichTextBox Rtb_debugger;

        public MyParser(string filename, RichTextBox Rtb_code, RichTextBox Rtb_debugger)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            this.Rtb_debugger = Rtb_debugger;
            this.Rtb_code = Rtb_code;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPEQ :
                //'&='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARETEQ :
                //'^='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEEQ :
                //'|='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLTEQ :
                //'<<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTEQ :
                //'>>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NULL :
                //null
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBERS :
                //Numbers
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ANDEXP :
                //<And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
                //<Argument List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAY :
                //<Array>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENTLIST :
                //<Assignment List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS2 :
                //<Class>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSLIST :
                //<Class List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPAREEXP :
                //<Compare Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENTS :
                //<elements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXP :
                //<Equality Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<Expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //<for loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONCALL :
                //<Function Call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDECL :
                //<Function Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATMENT :
                //<if statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INDEX :
                //<index>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INLINECONDITION :
                //<inline condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXP :
                //<Logical And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXP :
                //<Logical Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALXOREXP :
                //<Logical Xor Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OREXP :
                //<Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<Parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POSTFIXEXP :
                //<Postfix Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PREFIXEXP :
                //<Prefix Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHIFTEXP :
                //<Shift Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT :
                //<Statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENTLIST :
                //<Statment List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXP :
                //<Unary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP :
                //<while loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_LITERAL_TRUE :
                //<Literal> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_FALSE :
                //<Literal> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_NUMBERS :
                //<Literal> ::= Numbers
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_CHARLITERAL :
                //<Literal> ::= CharLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_STRINGLITERAL :
                //<Literal> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_NULL :
                //<Literal> ::= null
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <Class List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSLIST :
                //<Class List> ::= <Class List> <Class>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSLIST2 :
                //<Class List> ::= <Class>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_CLASS_IDENTIFIER :
                //<Class> ::= class Identifier <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECL_FUNCTION_IDENTIFIER_LPAREN_RPAREN :
                //<Function Decl> ::= function Identifier '(' <Parameters> ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECL_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RETURN_SEMI_RBRACE :
                //<Function Decl> ::= function Identifier '(' <Parameters> ')' '{' <Statment List> return <Expression> ';' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_IDENTIFIER_COMMA :
                //<Parameters> ::= Identifier ',' <Parameters>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_IDENTIFIER :
                //<Parameters> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<Parameters> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN :
                //<Function Call> ::= Identifier '(' <Argument List> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
                //<Argument List> ::= <Expression> ',' <Argument List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<Argument List> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST2 :
                //<Argument List> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENTLIST :
                //<Statment List> ::= <Statment List> <Statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENTLIST2 :
                //<Statment List> ::= <Statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT :
                //<Statment> ::= <Assignment List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_SEMI :
                //<Statment> ::= <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT2 :
                //<Statment> ::= <if statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT3 :
                //<Statment> ::= <inline condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT4 :
                //<Statment> ::= <for loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT5 :
                //<Statment> ::= <while loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT6 :
                //<Statment> ::= <Function Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_SEMI2 :
                //<Statment> ::= <Function Call> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <Statment List> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTLIST_COMMA_SEMI :
                //<Assignment List> ::= <Assignment List> ',' <Assignment> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTLIST_SEMI :
                //<Assignment List> ::= <Assignment> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ :
                //<Assignment> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATMENT_IF :
                //<if statment> ::= if <Expression> <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATMENT_IF_ELSE :
                //<if statment> ::= if <Expression> <Block> else <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INLINECONDITION_QUESTION_COLON_SEMI :
                //<inline condition> ::= <Expression> '?' <Expression> ':' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAY_LBRACKET_RBRACKET :
                //<Array> ::= '[' <elements> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS :
                //<elements> ::= <Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS_COMMA :
                //<elements> ::= <Literal> ',' <elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INDEX_IDENTIFIER_LBRACKET_NUMBERS_RBRACKET :
                //<index> ::= Identifier '[' Numbers ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INDEX_IDENTIFIER_LBRACKET_IDENTIFIER_RBRACKET :
                //<index> ::= Identifier '[' Identifier ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_LPAREN_SEMI_RPAREN :
                //<for loop> ::= for '(' <Assignment List> <Expression> ';' <Expression> ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_LPAREN_RPAREN :
                //<while loop> ::= while '(' <Expression> ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Or Exp> '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUSEQ :
                //<Expression> ::= <Or Exp> '+=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUSEQ :
                //<Expression> ::= <Or Exp> '-=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_TIMESEQ :
                //<Expression> ::= <Or Exp> '*=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_DIVEQ :
                //<Expression> ::= <Or Exp> '/=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_CARETEQ :
                //<Expression> ::= <Or Exp> '^=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AMPEQ :
                //<Expression> ::= <Or Exp> '&=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PIPEEQ :
                //<Expression> ::= <Or Exp> '|=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PERCENTEQ :
                //<Expression> ::= <Or Exp> '%=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTLTEQ :
                //<Expression> ::= <Or Exp> '<<=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTGTEQ :
                //<Expression> ::= <Or Exp> '>>=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OREXP_PIPEPIPE :
                //<Or Exp> ::= <Or Exp> '||' <And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OREXP :
                //<Or Exp> ::= <And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANDEXP_AMPAMP :
                //<And Exp> ::= <And Exp> '&&' <Logical Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANDEXP :
                //<And Exp> ::= <Logical Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP_PIPE :
                //<Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP :
                //<Logical Or Exp> ::= <Logical Xor Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP_CARET :
                //<Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP :
                //<Logical Xor Exp> ::= <Logical And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP_AMP :
                //<Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP :
                //<Logical And Exp> ::= <Equality Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EQEQ :
                //<Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EXCLAMEQ :
                //<Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP :
                //<Equality Exp> ::= <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LT :
                //<Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GT :
                //<Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LTEQ :
                //<Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GTEQ :
                //<Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP :
                //<Compare Exp> ::= <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_LTLT :
                //<Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_GTGT :
                //<Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP :
                //<Shift Exp> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP :
                //<Unary Exp> ::= <Postfix Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP2 :
                //<Unary Exp> ::= <Prefix Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP3 :
                //<Unary Exp> ::= <Expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIXEXP_PLUSPLUS :
                //<Postfix Exp> ::= <Expr> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIXEXP_MINUSMINUS :
                //<Postfix Exp> ::= <Expr> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PREFIXEXP_PLUSPLUS :
                //<Prefix Exp> ::= '++' <Expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PREFIXEXP_MINUSMINUS :
                //<Prefix Exp> ::= '--' <Expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LPAREN_RPAREN :
                //<Expr> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<Expr> ::= <Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR2 :
                //<Expr> ::= <Array>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_IDENTIFIER :
                //<Expr> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR3 :
                //<Expr> ::= <Function Call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR4 :
                //<Expr> ::= <index>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            int firstcharindex = Rtb_code.GetFirstCharIndexFromLine(args.UnexpectedToken.Location.LineNr);
            string currentlinetext = Rtb_code.Lines[args.UnexpectedToken.Location.LineNr];
            Rtb_code.Select(firstcharindex, currentlinetext.Length);
            Rtb_code.SelectionBackColor = Color.Red;
            Rtb_debugger.AppendText("Unexpected token: '" + args.UnexpectedToken.ToString()+ "'");
            Rtb_debugger.AppendText("\nAt line: '" + args.UnexpectedToken.Location.LineNr + "'");
            Rtb_debugger.AppendText("\nExpected to found: '" + args.ExpectedTokens.ToString() + "'");
        }

    }
}
