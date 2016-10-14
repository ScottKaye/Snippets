// For use with LINQPad (or any environment supporting object dumping)
void Main()
{
	new Vector<int>(3, 3, 3).Cross(new Vector<int>(0, 0, 0)).Dump("One zero vector");
	new Vector<int>(0, 0, 0).Cross(new Vector<int>(0, 0, 0)).Dump("Both zero vectors");
	(new Vector<int>(1, 1) - new Vector<int>(2, 2)).Cross(new Vector<int>(-4, 3) - new Vector<int>(-3, 4)).Dump("Parallel vectors");

	Vector<int>.Direction(
		start: new Vector<int>(5, 10),
		middle: new Vector<int>(10, 15),
		end: new Vector<int>(15, 20)
	).Dump("Straight vector direction");

	Vector<int>.Direction(
		start: new Vector<int>(5, 10),
		middle: new Vector<int>(10, 15),
		end: new Vector<int>(10, 10)
	).Dump("Counter-clockwise vector direction");
}
