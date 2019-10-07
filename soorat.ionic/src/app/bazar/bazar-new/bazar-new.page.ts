import { Component, OnInit } from '@angular/core';
import { ToastService } from 'src/app/_services/toast.service';
import { BazarService } from 'src/app/_services/bazar.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Bazar } from 'src/app/_models/bazar';

@Component({
  selector: 'app-bazar-new',
  templateUrl: './bazar-new.page.html',
  styleUrls: ['./bazar-new.page.scss'],
})
export class BazarNewPage implements OnInit {

  bazar: Bazar;
  private addBazarForm: FormGroup;

  constructor(private toastService: ToastService,
              private bazarService: BazarService,
              private router: Router,
              private formBuilder: FormBuilder) {

  this.addBazarForm = this.formBuilder.group({
        name: ['', [ Validators.required, Validators.maxLength(30)]],
        address: ['', [ Validators.required, Validators.maxLength(70)]],
      });
  }

  ngOnInit() {
  }

    addBazar() {
    this.bazarService.add(this.addBazarForm.value).subscribe( next => {
      this.toastService.success('ثبت با موفقیت انجام شد');
      this.router.navigate(['/bazar']);
    }, error => {
      this.toastService.error('ثبت با مشکل مواجه شد');
    });
  }

}
