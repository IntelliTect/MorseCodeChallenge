from node import Node


class MorseCode:

    _code_map = {
        " ": "  ",
        "a": ".- ",
        "b": "-... ",
        "c": "-.-. ",
        "d": "-.. ",
        "e": ". ",
        "f": "..-. ",
        "g": "--. ",
        "h": ".... ",
        "i": ".. ",
        "j": ".--- ",
        "k": "-.- ",
        "l": ".-.. ",
        "m": "-- ",
        "n": "-. ",
        "o": "--- ",
        "p": ".--. ",
        "q": "--.- ",
        "r": ".-. ",
        "s": "... ",
        "t": "- ",
        "u": "..- ",
        "v": "...- ",
        "w": ".-- ",
        "x": "-..- ",
        "y": "-.-- ",
        "z": "--.."
    }

    @staticmethod
    def convert_to(value):
        result = ""

        if value != "":
            for c in value:
                result += MorseCode._code_map[c.lower()]

        return result.rstrip()

    @staticmethod
    def convert_from(value):
        result = ""

        value = value + " "

        words = value.split("  ")

        for w in words:
            result += MorseCode._convert_from_word(w) + " "

        return result.rstrip()

    @staticmethod
    def _convert_from_word(word):
        result = ""
        chars = word.split(" ")

        for c in chars:
            for k, v in MorseCode._code_map.items():
                if v == (c + " "):
                    result += k

        return result
