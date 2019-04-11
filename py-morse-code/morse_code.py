from node import Node


class MorseCode:

    _code_map = {
        " ": " ",
        "a": ".-",
        "b": "-...",
        "c": "-.-.",
        "d": "-..",
        "e": ".",
        "f": "..-.",
        "g": "--.",
        "h": "....",
        "i": "..",
        "j": ".---",
        "k": "-.-",
        "l": ".-..",
        "m": "--",
        "n": "-.",
        "o": "---",
        "p": ".--.",
        "q": "--.-",
        "r": ".-.",
        "s": "...",
        "t": "-",
        "u": "..-",
        "v": "...-",
        "w": ".--",
        "x": "-..-",
        "y": "-.--",
        "z": "--.."
    }

    @classmethod
    def convert_to(cls, value):
        if not value:
            return ""
        else:
            results = [
                cls._code_map[c.lower()]
                for c in value
            ]

            return " ".join(results)

    @classmethod
    def convert_from(cls, value):
        value = f"{value} "

        words = value.split("  ")

        results = [
            cls._convert_from_word(w)
            for w in words
        ]

        return " ".join(results)

    @classmethod
    def _convert_from_word(cls, word):
        results = []
        chars = word.split(" ")

        for c in chars:
            for k, v in cls._code_map.items():
                if v == c:
                    results.append(k)

        return "".join(results)
