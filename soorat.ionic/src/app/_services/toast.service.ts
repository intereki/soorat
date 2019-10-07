import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

constructor(private toastController: ToastController) { }

async success(msg: string) {
  const toast = await this.toastController.create({
    message: msg,
    color: 'success',
    duration: 3000,
    translucent: true
  });
  toast.present();
}

async error(msg: string) {
  const toast = await this.toastController.create({
    message: msg,
    color: 'danger',
    duration: 3000,
    translucent: true
  });
  toast.present();
}

async warning(msg: string) {
  const toast = await this.toastController.create({
    message: msg,
    color: 'warning',
    duration: 3000,
    translucent: true
  });
  toast.present();
}

async info(msg: string) {
  const toast = await this.toastController.create({
    message: msg,
    color: 'primary',
    duration: 3000,
    translucent: true
  });
  toast.present();
}

}
