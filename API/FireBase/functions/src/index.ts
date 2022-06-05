

// // Start writing Firebase Functions
// // https://firebase.google.com/docs/functions/typescript
//
const createUserRaw = require('./users/createUsers.onCall')
export const createUsers =  createUserRaw.createUsers

const newContactToHubSotRaw = require('./send/newContactToHubSot.onCreate')
export const newContactToHubSot = newContactToHubSotRaw.newContactToHubSot

const newUsersRaw = require('./httpRequest/newUsers.onRequest')
export const newUsers = newUsersRaw.newUsers