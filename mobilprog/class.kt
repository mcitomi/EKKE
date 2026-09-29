    fun main() {
        val kotlin = "🙂"
        println(kotlin)

        var a = Animal("Bruku", -1)
        a.describe()
        
        var dog = Dog("Rex", 3, "Labrador")
        dog.describe()
        // dog.jump()
        
        var cat = Cat("Felix")
        // cat.jump()
        
        // list osztály nem változtatható - unmutable mint a val - ezért nem működik az add metódusa
        // De ezért van MutableList
        var animals : MutableList<Attraction> = mutableListOf()
        animals.add(dog)
        animals.add(cat)
        animals.forEach{it.jump()}
        
        val btnOkListener = BottonClickActionListener()
        btnOkListener.execute("OK")
        
        // Kotlin SAM konverzió
        // Ennem során egy SAM interface megvalósító osztály metódusa helyettesíthető egy Lambdaval.
        val buttonAction = Action{buttonName -> println("Button - $buttonName clicked.")}
        buttonAction.execute("Cancel")
    }

    // minden publikus alapból
    // Elsődleges vagy primary konstruktor az osztály nevéből alakítható ki
    open class Animal constructor(var name: String, var age: Int) : Attraction {
        // var name: String = "";
        // var age: Int = 0;

        // Init blokk konstruktorral együtt fut le
        init {
            
            if (age < 0) 
                age = 0
        }

        var color: String = ""
        
        // Bármennyi másodlagos konstruktor lehet
        // Tagváltozója nincs, csak paramétere
        // Hivatkozni kell az elsődleges konstruktorra, másképp hibát ír
        constructor(name: String, age: Int, color: String) : this(name, age) {
            // mindig az adott példányra hivatkozik
            this.color = color
        }

        open fun describe() {
            println("name: $name, age: $age")
        }
        
        override fun jump() {
            println("$name jumps!")
        }
    }
    
    interface Attraction {
        fun jump()
    }
    
    class Cat(val name: String) : Attraction {
        override fun jump() {
            println("Cat - $name jumps ^^")
        }
    }
    
    // Alapból minden osztály zárt az örökrése, ki kell nyitni
    class Dog(name: String, age: Int, var breed: String) : Animal(name, age) {
        fun fetch() {
            println("$name fetched a ball!")
        }
        
        // felül lehet definiálni az ős metódusait, de csak amelyik nyitott az open-el
        override fun describe() {
            println("Dog name: $name, age: $age, breed: $breed")
        }
    }

    	
    // SAM konverzió
    // Single Abstract Method
    // Interface-k egyik típusa a SAM interface, vagy funkcionális interface
    // SAM = Egyetlen Abstract Metódus - csak egy lehet benne, kettő már nem
    // Azért abstract, mert nincs a kódblokk definiálva, csak a paraméterei és a visszatérő értéke.
    // Ha interface elé kiírjuk a fun szót, jelezzük hogy az a cél hogy egyetlen metódusa legyen mert SAM
    fun interface Action {
        fun execute(input: String)
        // fun another()
    }
    
    class BottonClickActionListener : Action {
        
        override fun execute(buttonName: String) {
            println("Button - $buttonName clicked.")
        }
    }