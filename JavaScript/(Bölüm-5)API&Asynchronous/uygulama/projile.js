class Profile{
    constructor(){
        this.clientId = '',
        this.clientSecret = ''
    }
    async getProfile(username){
        let profileResponses = await fetch(`https://jsonplaceholder.typicode.com/users?username=${username}`)
        let profile = await profileResponses.json()
        let todosRes = await fetch(`https://jsonplaceholder.typicode.com/todos?userId=${profile[0].id}`)
        let todos = await todosRes.json()
        return { "profile": profile,"todos":todos}
    }
}