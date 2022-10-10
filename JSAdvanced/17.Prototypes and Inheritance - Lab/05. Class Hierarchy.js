//function hierarchy() {
    class Figure {
        constructor(units) {
            this.units = units;
        }
        changeUnits() {

        }
        toString() {
            return `Figures units: ${this.units}`;
        }
    };
    class Circle extends Figure {
        constructor(radius) {
            super(units);
            this.radius = radius;
        }
        toString() {
            let base = super.toString().slice(0, -1);
            return `${base} Area: ${this.area} - radius: ${this.radius}`;
        }
    }
    class Rectangle extends Figure {
        constructor(width, height) {
            super(units);
            this.width = width;
            this.height = height;
        }
        toString() {
            let base = super.toString().slice(0, -1);
            return `${base} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    let c = new Circle(5);
    console.log(c.area); // 78.53981633974483
    console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

    let r = new Rectangle(3, 4, 'mm');
    console.log(r.area); // 1200 
    console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40
    r.changeUnits('cm');
    console.log(r.area); // 12
    console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4
    c.changeUnits('mm');
    console.log(c.area); // 7853.981633974483
    console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
//}