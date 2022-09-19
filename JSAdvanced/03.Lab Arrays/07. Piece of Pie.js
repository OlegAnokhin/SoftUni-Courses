function tacePiece(arr, start, end){
    let result = arr.slice(arr.indexOf(start), arr.indexOf(end)+1);
    return result;
}
console.log(tacePiece(['Pumpkin Pie','Key Lime Pie','Cherry Pie','Lemon Meringue Pie','Sugar Cream Pie'],'Key Lime Pie','Lemon Meringue Pie'));
console.log(tacePiece(['Apple Crisp', 'Mississippi Mud Pie', 'Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie'], 'Pot Pie', 'Smoked Fish Pie'));