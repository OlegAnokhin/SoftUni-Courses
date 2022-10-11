function solve() {
    class Balloon {
        constructor(color, hasWeight) {
            this.color = color;
            this.hasWeight = hasWeight;
        }
    }
    class PartyBalloon extends Balloon {
        constructor(color, hasWeight, ribbonColor, ribbonLength) {
            super(color, hasWeight);
            this.ribbonColor = ribbonColor;
            this.ribbonLength = ribbonLength;
            this._ribbon = {
               color: ribbonColor,
               length: ribbonLength
            }
        }
        get ribbon() {
            return this._ribbon
        }
    }
    class BirthdayBalloon extends PartyBalloon {
        constructor(color, hasWeight, ribbonColor, ribbonLength, text) {
            super(color, hasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }
        get text(){
            return this._text
        }
    }
    return {
       Balloon: Balloon,
       PartyBalloon: PartyBalloon,
       BirthdayBalloon: BirthdayBalloon
    }
}
let classes = solve();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5,"red", 10.25);
let testBirthdayBalloon = new classes.BirthdayBalloon("black", 666,"dark-black", 999, "Evil");
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon)
console.log(testBirthdayBalloon)