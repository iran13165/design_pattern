class Rectangle
{
    constructor(width, height)
    {
        this._width = width;
        this._height = height;
    }
    /**
     * @param {number} value
     */
    get width()
    {
        return this._width;
    }
    get height()
    {
        return this._height;
    }
    set width(value)
    {
        this._width  = value;
    }
    /**
     * @param {number} value
     */
    set height(value)
    {
        this._height = value;
    }
    get Area()
    {
        return this._width * this._height;
    }
    ToString()
    {
        return `Width: ${this._width}, Height: ${this._height}`;
    }
}
class Square extends Rectangle
{
    constructor(width){
        super();
        super.width = width;
        super.height = width;
    }
}
let UseIt = function(rc)
{
    let width = rc.width;
    rc.height = 10;
    console.log(`Expected ${10*width}` + ` but got ${rc.Area}`);
}

var r = new Rectangle(2,3);
console.log(`${r.ToString()} has area = ${r.Area}` );
UseIt(r);
var s = new Square(4);
s.width = 5;
console.log(`${s.ToString()} has area = ${s.Area}` );
UseIt(s);