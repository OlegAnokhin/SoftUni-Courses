function start(state, game){
   let wizard = game.createWizard(state);
    window.requestAnimationFrame(gameLoop.bind(null, wizard));
}

function gameLoop(wizard){
    console.log("gameLoop");
    window.requestAnimationFrame(gameLoop.bind(null, wizard));
}