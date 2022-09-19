function smallestNum(input) {
    console.log(input
        .sort((a, b) => a - b)
        .slice(0, 2)
        .join(" "));
}
smallestNum([30, 15, 50, 5]);
smallestNum([3, 0, 10, 4, 7, 3]);