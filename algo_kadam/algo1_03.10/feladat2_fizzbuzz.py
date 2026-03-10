def fizz_buzz(n):
    #for i in range(1, n + 1, 1): # start stop step params
    #    print(f"{i}. szöveg")

    for i in range(1, n + 1):
        if(i % 3 == 0 and i % 5 ==0):
            print("FizzBuzz")
        else:
            if(i % 3 == 0):
                print("Fizz")
            
            else:
                if(i % 5 == 0) :
                    print("Buzz")
                else:
                    print(i)

fizz_buzz(20)
