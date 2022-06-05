import * as functions from 'firebase-functions';
const Hubspot = require('hubspot')


export const newContactToHubSot = functions.database.ref(`users/{firstname}`).onCreate(async (snapshot, context) => {

    const data = snapshot.val()
    functions.logger.log("debut de la création du nouveau client hubspot")
    functions.logger.log("data value")
    functions.logger.log(data)

    const hubspot = new Hubspot({
        apiKey: "eu1-c208-3967-4dfa-8eea-552c4415e01f",
        checkLimit: false // (Optional) Specify whether to check the API limit on each call. Default: true
      })

      const contactObj = {
        "properties": [
          { "property": "firstname","value": data.firstname },
          { "property": "email", "value": data.email }
        ]
      };


    try {
        if (data) {
           const hubspotContact = await hubspot.contacts.create(contactObj);
           functions.logger.log(hubspotContact)
        }
    } catch (e) {
        functions.logger.error("une erreur est survenue lors de la récuperation des information")
        throw e
    }
})