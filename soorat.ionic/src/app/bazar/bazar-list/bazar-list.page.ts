import { Component, OnInit } from '@angular/core';
import { BazarService } from 'src/app/_services/bazar.service';
import { ToastService } from 'src/app/_services/toast.service';
import { Bazar } from 'src/app/_models/bazar';
import { ActionSheetController } from '@ionic/angular';

@Component({
  selector: 'app-bazar-list',
  templateUrl: './bazar-list.page.html',
  styleUrls: ['./bazar-list.page.scss'],
})
export class BazarListPage implements OnInit {

  bazars: Bazar[];
  id: number;

  constructor(private toastService: ToastService, private bazaService: BazarService,
              public actionSheetController: ActionSheetController) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.bazaService.getAll().subscribe(bazars => {
      this.bazars = bazars;
    }, error => {
      this.toastService.error(error);
    });
  }

  edit(id: number) {
    console.log('edit: ' + id);
  }

  delete(id: number) {
    this.bazaService.delete(id).subscribe( () => {
      this.bazars.slice(this.bazars.findIndex(p => p.bazarId === id), 1);
      this.toastService.success('با موفقیت حذف شد');
    }, error => {
      this.toastService.error(error);
    });
  }

  async deleteActionSheet(id: number) {
    this.id = id;
    const actionSheet = await this.actionSheetController.create({
      header: 'آیا مطمئن هستید میخواهید بازار مورد نظر حذف شود؟',
      buttons: [{
        text: 'حذف',
        role: 'destructive',
        icon: 'trash',
        handler: () => {
          this.delete(this.id);
        }
      }, {
        text: 'لغو',
        icon: 'close',
        role: 'cancel'
      }]
    });
    await actionSheet.present();
  }
}
