function request(obj) {
    let validMethod = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let supportVer = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1" , "HTTP/2.0"];
    let specialSymbols = ["<", ">", "\\", "&", "'", `"`];
    let uriRegex = /^[\w.]+$/g;
    if (!validMethod.includes(obj.method)) {
        throw new Error("Invalid request header: Invalid Method");
    }
    if(!obj.hasOwnProperty("uri")){
        throw new Error("Invalid request header: Invalid URI");
    }
    if(obj.uri!== "*" && !obj.uri.match(uriRegex)){
        throw new Error("Invalid request header: Invalid URI");
    }
    if(!supportVer.includes(obj.version)){
        throw new Error("Invalid request header: Invalid Version");
    }
    if(!obj.hasOwnProperty("message")){
        throw new Error("Invalid request header: Invalid Message");
    }
    for(let ch of obj.message){
        if(specialSymbols.includes(ch)){
            throw new Error("Invalid request header: Invalid Message");
        }
    }
    return obj;
}

request({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'abv'
});