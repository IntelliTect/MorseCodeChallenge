from morse_code import MorseCode


def run_app():
    v = input("Please enter something to be converted to morse code: ")

    result = MorseCode.convert_to(v)

    print(f"result: {result}")
    print()

    test = MorseCode.convert_from(result)

    print("Results for converting back")
    print("---------------------------------------------------")

    print(test)


run_app()
