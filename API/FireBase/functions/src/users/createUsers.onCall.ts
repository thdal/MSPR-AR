import * as functions from 'firebase-functions';
import { UsersInscriptionTab } from '../models/UsersInscriptionTab.model';
import { admin } from '../utils/utils';
import { createTabUser } from './createTabUser.fn';

export async function createUsers(data: any) {
    const email = data.email
    const firstname = data.firstname

    try {
        if (data) {

            functions.logger.log("***** Création Utilisateur ******")

            const userInscriptionFirebase = {
                email: email,
                displayName: `${firstname}`,
                disabled: false,
            }

            const usersRecord = await admin.auth().createUser(userInscriptionFirebase)

            if (usersRecord) {

                functions.logger.log("mise en base des infos client")

                const formData: UsersInscriptionTab = {
                    firstname: firstname,
                    email: email,
                }

                await createTabUser(usersRecord, formData)
                /*  const tabUserlink = admin.database().ref(`users/${usersRecord.uid}`)
                 const tabUserNap = tabUserlink.once('value')
                 const tabUser = (await tabUserNap).val() */
                //a voir ...
                /* if(tabUser !== null){
                    await checkEmailValidated(email, usersRecord.uid)
                }
                else{
                    functions.logger.log("la table du user est absent")                    
                } */
            }
            else {
                functions.logger.error("Une erreur est survenue lors de la création du user")
            }
        }
        else {
            functions.logger.error("Utilisateur deja creer")
        }
    }
    catch (e) {
        functions.logger.error(e)
        throw e
    }
}