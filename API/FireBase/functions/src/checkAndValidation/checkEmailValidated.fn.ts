import { admin } from '../utils/utils';

export async function checkEmailValidated(email: string, uid: string) {

    try {

        const userData = await admin.database().ref(`users/${uid}`).once('value')
        const user = userData.val()

        if (user.emailVerified === false) {

        }
        else{
            throw new Error("Une erreur est survenu lors de l'envoi du mail de confirmation")
        }
    } catch (e) {
        throw e
    }
}