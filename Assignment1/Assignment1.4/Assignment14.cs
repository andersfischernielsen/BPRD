using System;
using System.Collections.Generic;
using System.Data;

namespace Assignment14
{
    public abstract class Expr
    {
        public abstract int Eval(Dictionary<string, int> env);
        public abstract Expr Simplify();
    }

    public class CstI : Expr
    {
        public readonly int I { get; set; }

		public CstI(int i) { I = i; }

        public override string ToString()
        {
            return I.ToString();
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return I;
        }

        public override Expr Simplify()
        {
            return this;
        }
    }

    public class Var : Expr
    {
        public readonly string Name { get; set; }

        public Var(string name) { Name = name; }

        public override string ToString()
        {
            return Name;
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return env[Name];
        }

        public override Expr Simplify()
        {
            return this;
        }
    }

    public abstract class Binop : Expr
    {
        protected Binop(Expr expr1, Expr expr2) { Expr1 = expr1; Expr2 = expr2; }

        public readonly Expr Expr1 { get; private set; }
        public readonly Expr Expr2 { get; private set; }
    }

    public class Add : Binop
    {
        public Add(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " + " + Expr2 + ")"; // tostring not neccesary.
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) + Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1 == new CstI(0) && Expr2 == new CstI(0))
            {
                return new CstI(0);
            }
            if (Expr1 == new CstI(0))
            {
                return Expr2;
            }
            if (Expr2 == new CstI(0))
            {
                return Expr1;
            }

            return this;
        }
    }

    public class Mul : Binop
    {
        public Mul(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " * " + Expr2 + ")"; // tostring not neccesary.
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) * Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1 == new CstI(0) || Expr2 == new CstI(0))
            {
                return new CstI(0);
            }
            if (Expr1 == new CstI(1))
            {
                return Expr2;
            }
            if (Expr2 == new CstI(1))
            {
                return Expr1;
            }

            return this;
        }
    }

    public class Sub : Binop
    {
        public Sub(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " - " + Expr2 + ")"; // tostring not neccesary.
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) - Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1 == new CstI(0) && Expr2 == new CstI(0))
            {
                return new CstI(0);
            }
            if (Expr1 == Expr2)
            {
                return new CstI(0);
            }
            if (Expr2 == new CstI(0))
            {
                return Expr1;
            }

            return this;
        }
    }
}
