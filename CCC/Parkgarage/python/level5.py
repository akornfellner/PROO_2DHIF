import math


def get_inputs(filename: str):
    with open(filename, "r") as file:
        lines = file.read().splitlines()

    first = lines[0].split(" ")
    N = int(first[0])
    M = int(first[1])

    p = lines[1].split(" ")

    prices = []

    for v in p:
        prices.append(int(v))

    w = lines[2].split(" ")

    weights = []

    for v in w:
        weights.append(int(v))

    n = lines[3].split(" ")

    numbers = []

    for v in n:
        numbers.append(int(v))

    return (N, M, prices, weights, numbers)


def find_free(arr: list) -> int:
    for i in range(len(arr)):
        if arr[i] == -1:
            return i


def find_car(arr: list, number: int) -> int:
    for i in range(len(arr)):
        if arr[i] == number:
            return i


def mult(n: int) -> int:
    return int(math.ceil(n/100))


for i in range(1, 6):
    N, M, prices, weights, numbers = get_inputs("input5/input"+str(i))

    spaces = [-1 for x in range(N)]
    amount = 0
    count = 0
    waiting = []

    while len(numbers) > 0:
        if count == N:
            while numbers[0] > 0:
                waiting.append(numbers.pop(0))
            number = numbers.pop(0)
        else:
            if len(waiting) > 0:
                number = waiting.pop(0)
            else:
                number = numbers.pop(0)
        if number > 0:
            space = find_free(spaces)
            spaces[space] = number
            count += 1
        else:
            if -number in waiting:
                waiting.remove(-number)
                continue
            space = find_car(spaces, -number)
            spaces[space] = -1
            amount += prices[space] * mult(weights[-number-1])
            count -= 1

    print(amount)
