def get_inputs(filename: str):
    with open(filename, "r") as file:
        lines = file.read().splitlines()

    first = lines[0].split(" ")
    N = int(first[0])
    M = int(first[1])

    n = lines[1].split(" ")

    numbers = []

    for v in n:
        numbers.append(int(v))

    return (N, M, numbers)


for i in range(1, 6):
    N, M, numbers = get_inputs("input2/input"+str(i))

    waiting = 0
    parking = 0

    max_waiting = 0
    max_parking = 0

    for number in numbers:
        if number > 0:
            if parking < N:
                parking += 1
            else:
                waiting += 1
        else:
            if waiting > 0:
                waiting -= 1
            else:
                parking -= 1

        if parking > max_parking:
            max_parking = parking
        if waiting > max_waiting:
            max_waiting = waiting

    print(max_parking, max_waiting)
