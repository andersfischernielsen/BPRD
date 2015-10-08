using System;
using System.Collections.Generic;
using System.Data;

namespace Assignment14
{
    public abstract class Expr
    {
        public abstract int Eval(Dictionary<string, int> env);
        public abstract Expr Simplify();
        public abstract bool Equals(Expr other);
    }

    public class CstI : Expr
    {
        public int I { get; }

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

        public override bool Equals(Expr other)
        {
            var that = other as CstI;
            return I == that?.I;
        }
    }

    public class Var : Expr
    {
        public string Name { get; }

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

        public override bool Equals(Expr other)
        {
            var that = other as Var;
            return Name == that?.Name;
        }
    }

    public abstract class Binop : Expr
    {
        protected Binop(Expr expr1, Expr expr2) { Expr1 = expr1; Expr2 = expr2; }

        public Expr Expr1 { get; }
        public Expr Expr2 { get; }

        public override bool Equals(Expr other)
        {
            var that = other as Binop;
            return Expr1.Equals(that?.Expr1) && Expr2.Equals(that?.Expr1);
        }
    }

    public class Add : Binop
    {
        public Add(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " + " + Expr2 + ")";
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) + Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1.Equals(new CstI(0)) && Expr2.Equals(new CstI(0)))
            {
                return new CstI(0);
            }
            if (Expr1.Equals(new CstI(0)))
            {
                return Expr2;
            }

            return Expr2.Equals(new CstI(0)) ? Expr1 : this;
        }
    }

    public class Mul : Binop
    {
        public Mul(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " * " + Expr2 + ")";
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) * Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1.Equals(new CstI(0)) || Expr2.Equals(new CstI(0)))
            {
                return new CstI(0);
            }
            if (Expr1.Equals(new CstI(1)))
            {
                return Expr2;
            }

            return Expr2.Equals(new CstI(1)) ? Expr1 : this;
        }
    }

    public class Sub : Binop
    {
        public Sub(Expr expr1, Expr expr2) : base(expr1, expr2) { }

        public override string ToString()
        {
            return "(" + Expr1 + " - " + Expr2 + ")";
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return Expr1.Eval(env) - Expr2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (Expr1.Equals(new CstI(0)) && Expr2.Equals(new CstI(0)))
            {
                return new CstI(0);
            }
            if (Expr1.Equals(Expr2))
            {
                return new CstI(0);
            }

            return Expr2.Equals(new CstI(0)) ? Expr1 : this;
        }
    }

    public abstract class Unop : Expr
    {
        public Expr Expr { get; }

        protected Unop(Expr expr1) { Expr = expr1; }

        public override bool Equals(Expr other)
        {
            var that = other as Unop;
            return Expr.Equals(that?.Expr);
        }
    }

    public class Sqrt : Unop
    {
        public Sqrt(Expr expr1) : base(expr1) { }

        public override int Eval(Dictionary<string, int> env)
        {
            var eval = Expr.Eval(env);
            return eval * eval;
        }

        public override Expr Simplify()
        {
            return this;
        }
    }
}
