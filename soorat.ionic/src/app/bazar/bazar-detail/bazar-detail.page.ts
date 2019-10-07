import { Component, OnInit } from '@angular/core';
import { Bazar } from 'src/app/_models/bazar';
import { ToastService } from 'src/app/_services/toast.service';
import { BazarService } from 'src/app/_services/bazar.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bazar-detail',
  templateUrl: './bazar-detail.page.html',
  styleUrls: ['./bazar-detail.page.scss'],
})
export class BazarDetailPage implements OnInit {

  bazar: Bazar;

  constructor(private toastService: ToastService,
              private bazarService: BazarService,
              private router: Router,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.bazar = data.bazar;
    });
  }

    addBazar() {
    this.bazarService.update(this.bazar.bazarId, this.bazar).subscribe( next => {
      this.toastService.success('ثبت با موفقیت انجام شد');
      this.router.navigate(['/bazar']);
    }, error => {
      this.toastService.error('ثبت با مشکل مواجه شد');
    });
  }

}
