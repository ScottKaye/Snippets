// Credits: 
// https://searchcode.com/codesearch/view/66242529/
// https://vvvv.org/documentation/3d-vector-mathematics
// https://github.com/SFML/SFML/blob/master/include/SFML/System/Vector3.inl
public struct Vector<T> : IEquatable<Vector<T>>
	where T : struct
{
	public readonly T X, Y, Z;

	public Vector(T x, T y, T z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector(T x, T y)
	{
		X = x;
		Y = y;
		Z = default(T);
	}

	public T Length => (T)Math.Sqrt((dynamic)X * X + (dynamic)Y * Y + (dynamic)Z * Z);

	private static Vector<T> BasicOp(dynamic left, T right, Func<dynamic, dynamic, T> op) => new Vector<T>(
			x: op(left.X, right),
			y: op(left.Y, right),
			z: op(left.Z, right)
		);

	private static Vector<T> VectorOp(dynamic left, dynamic right, Func<dynamic, dynamic, T> op) => new Vector<T>(
			x: op(left.X, right.X),
			y: op(left.Y, right.Y),
			z: op(left.Z, right.Z)
		);

	public override int GetHashCode() => unchecked((dynamic)X * (dynamic)Y * 2 * (dynamic)Z * 4);
	public bool Equals(Vector<T> other) => this == other;
	public override bool Equals(object other) => other != null && this == (Vector<T>)other;
	public static bool operator ==(Vector<T> a, Vector<T> b) => (dynamic)a.X == b.X && (dynamic)a.Y == b.Y && (dynamic)a.Z == b.Z;
	public static bool operator !=(Vector<T> a, Vector<T> b) => (dynamic)a.X != b.X || (dynamic)a.Y != b.Y || (dynamic)a.Z != b.Z;

	public static Vector<T> operator +(Vector<T> left, T right) => BasicOp(left, right, (a, b) => a + b);
	public static Vector<T> operator -(Vector<T> left, T right) => BasicOp(left, right, (a, b) => a - b);
	public static Vector<T> operator *(Vector<T> left, T right) => BasicOp(left, right, (a, b) => a * b);
	public static Vector<T> operator /(Vector<T> left, T right) => BasicOp(left, right, (a, b) => a / b);

	public static Vector<T> operator +(Vector<T> left, Vector<T> right) => VectorOp(left, right, (a, b) => a + b);
	public static Vector<T> operator -(Vector<T> left, Vector<T> right) => VectorOp(left, right, (a, b) => a - b);
	public static Vector<T> operator *(Vector<T> left, Vector<T> right) => VectorOp(left, right, (a, b) => a * b);
	public static Vector<T> operator /(Vector<T> left, Vector<T> right) => VectorOp(left, right, (a, b) => a / b);

	public Vector<T> Cross(Vector<T> right) => new Vector<T>(
			(dynamic)Y * right.Z - (dynamic)Z * right.Y,
			(dynamic)Z * right.X - (dynamic)X * right.Z,
			(dynamic)X * right.Y - (dynamic)Y * right.X
		);

	public static VectorDirection Direction(Vector<T> start, Vector<T> middle, Vector<T> end)
	{
		dynamic z = (middle - start).Cross(end - middle).Z;
		return z > 0
			? VectorDirection.Clockwise
			: z < 0
				? VectorDirection.CounterClockwise
				: VectorDirection.Straight;
	}

	public enum VectorDirection
	{
		Clockwise,
		CounterClockwise,
		Straight
	}
}
