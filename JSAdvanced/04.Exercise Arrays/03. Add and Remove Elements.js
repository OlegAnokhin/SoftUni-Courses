function addAndRemove(commands){
    let result = [];
    let num = 1;
    commands.forEach(cmd => {
        cmd === "add" ? result.push(num) : result.pop();
        num++;
    });
    return result.length === 0 ? "Empty" : result.join("\n");
    //  for (let cmd of commands){
    //     switch(cmd){
    //         case "add" :
    //         result.push(num);
    //         num ++;
    //         break;
    //         case "remove" :
    //         result.pop();
    //         num++;
    //         break;
    //     }
    //  }
    //  if (result.length === 0){
    //     console.log("Empty");
    //  }else {
    //      console.log(result.join("\n"));
    //  }    
}
console.log(addAndRemove(['add', 'add', 'remove', 'add', 'add']));