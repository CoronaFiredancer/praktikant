namespace Praktikant.Models {
	public enum FruitColor {
		None, Green, Red, Yellow
	}

	public enum FruitType {
		None, Apple, Pear, Banana
	}

	public class Fruit {

		public FruitType Type { get; set; }
		public FruitColor Color { get; set; }
		public int Weight { get; set; }

		public Fruit(FruitType type, FruitColor color, int weight) {
			Type = type;
			Color = color;
			Weight = weight;
		}

		public Fruit() {
			Type = FruitType.None;
			Color = FruitColor.None;
			Weight = 0;
		}

		public override string ToString() {
			return "[" + Color + ", " + Type + ", " + Weight + "]";
		}
	}
}
