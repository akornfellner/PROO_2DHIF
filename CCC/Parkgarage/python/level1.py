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


for i in range(1, 4):
    N, M, numbers = get_inputs("input1/input"+str(i))
    max = 0
    count = 0
    for number in numbers:
        if number > 0:
            count += 1
        else:
            count -= 1
        if count > max:
            max = count
    print(max)
