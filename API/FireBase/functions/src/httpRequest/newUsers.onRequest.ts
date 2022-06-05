import * as functions from 'firebase-functions';
import { createUsers } from '../users/createUsers.onCall';

export const newUsers = functions.https.onRequest(async (req, res) => {

    functions.logger.log(req.body)

    const data = JSON.parse(JSON.stringify(req.body))
    const firstname = data.firstname
    const email = data.email
    functions.logger.log("data request")
    functions.logger.log(firstname)
    functions.logger.log(email)

    try {
        const queryData = {
            firstname: firstname,
            email: email
        }

        await createUsers(queryData)
        res.send("Info send")
        res.status(200)
    }
    catch (e) {
        functions.logger.error(e)
        res.status(500)
    }
})