using System;
using System.Linq.Expressions;
using System.Reflection;

public static class Extensions
{
	// Get the accessed member from an expression
	public static MemberInfo GetMember<T, U>(this Expression<Func<T, U>> exp) => (((exp.Body as UnaryExpression)?.Operand ?? exp.Body) as MemberExpression).Member;
}
