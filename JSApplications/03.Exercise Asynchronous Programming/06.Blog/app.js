function attachEvents() {
    const postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
    const postsCommentsUrl = `http://localhost:3030/jsonstore/blog/comments`;    
    document.getElementById('btnLoadPosts').addEventListener('click', getPost);
    document.getElementById('btnViewPost').addEventListener('click', getComments);
    
    async function getPost() {
        const selectOp = document.getElementById('posts');
        selectOp.innerHTML = '';
        const respons = await fetch(postsUrl);
        const data = await respons.json();
        Object.values(data).forEach(post => {
            const op = document.createElement('option');
            op.value = post.id;
            op.textContent = post.title;
            selectOp.appendChild(op);
        })
    }
    async function getComments() {
        debugger
        const selectedOp = document.getElementById('posts').selectedOptions[0].value;
        const titleElement = document.getElementById('post-title');
        const postBodyElement = document.getElementById('post-body');
        const postUlElement = document.getElementById('post-comments');
        postUlElement.innerHTML = '';

        const postResponse = await fetch(postsUrl);
        const postData = await postResponse.json();
        const commentsRespons = await fetch(postsCommentsUrl);
        const commentsData = await commentsRespons.json();
        const selectedPOst = Object.values(postData).find(post => post.id == selectedOp);
        titleElement.textContent = selectedPOst.title;
        postBodyElement.textContent = selectedPOst.body;
        const comments = Object.values(commentsData).filter(c => c.postId === selectedOp);
        comments.forEach(c => {
            const li = document.createElement('li');
            li.textContent = c.text;
            postUlElement.appendChild(li);
        })
    }
}
attachEvents();