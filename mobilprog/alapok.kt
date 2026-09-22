/**
 * You can edit, run, and share this code.
 * play.kotlinlang.org
 */
fun main() {
    // Változók
    
    var variable1 = 1
   	var value1 = 1
    
    variable1 = variable1 + 1
    
    lateinit var asd : String	// Majd később kap értéket
    // minden változónak kezdő érétk kell, NULL védett nyelv
    
    //println(asd) // Hibát ír fordítási időben
    
    //value1 = value1 + 1
    
    // Egész számok
    // Byte(8bit), Short(16bit), Int(32bit), Long(64bit)
    var a : Long = 1
    var b = 1L	// 1L = Long szám
    println(a + 2_147_483_647)	// ha int marad, akkor túl csordul (alapvetőleg int)
    
    // Lebegőpontos
    // Double(64bit), Float(32bit)
    var c = 3.14 // alapból Double
    var d : Float = 3.14f // így float
    
    var bool = true
    
    println(bool)
    
    // Karakterek
    // Char, String
    
    var A = 'A'
    var apple = A + "pple"
    
    println(apple)
    
    // Tömbök és listák
    var array = arrayOf(1,2,3)
    var list = listOf(1,2,3)
    
    println(array)
    println(list)
    
    array.forEach(){x -> println(x)}
    array.forEach{x -> println(x)}
    array.forEach{println(it)}	// it az adott értékre hivatkozik
    
    var array2 = Array(3){1}	// 3 hosszú, mindegyik 1 értékű
	array2.forEach{println(it)}
    
    // Any - minden osztály őse (más nyelvekben Object)
    // Unit - Nem mindig kell kiírni, pl Main() után sincs (más nyelvekben void)
    // Nothing - mindennek van visszatérő értéke valójában
    
  	// Függvény típus
    // (X,Y) -> Z
    var add : (Int, Int) -> Int
    add = {x: Int, y: Int -> x + y}
    //println(add(6,7))
    
    
    add = ::anotherAdd	// :: referencia operátor
    println(add(6, 7))
    
    //println(anotherAdd(13, 42))
    
    // Nullázható és nem null tipusok
    var ref : Int? = 1	// Nullable Int, alapból az int nem lehet null, a ?-el megadjuk hogy null is lehet a változó (typescripthez/c#-hoz hasonlóan)
    ref = null
    
    if(ref != null) {
        ref = ref + 1
    }
    
    ref = ref?.inc()	// safe call operátor, csak akkor futtatja a inc()-et ha nem null, így elkerüli a hibát
    
    println(ref)
    
    
    
    
}
fun anotherAdd(a: Int, b: Int) : Int {
        return a + b
}
