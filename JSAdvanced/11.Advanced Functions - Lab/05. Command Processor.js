function solve() {
    let input = "";
    return {
        append: (s) => input += s,
        removeStart: (n) => input = input.substring(n),
        removeEnd: (n) => input = input.substring(0, input.length - n),
        print: () => console.log(input)
    }
}
let cmd = solve();
cmd.append("Oleg ");
cmd.append("Anokhin");
cmd.print();