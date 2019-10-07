import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BazarListPage } from './bazar-list/bazar-list.page';
import { Routes, RouterModule } from '@angular/router';
import { BazarListPageModule } from './bazar-list/bazar-list.module';
import { BazarNewPageModule } from './bazar-new/bazar-new.module';
import { BazarDetailPageModule } from './bazar-detail/bazar-detail.module';
import { FormsModule } from '@angular/forms';
import { BazarDetailResolver } from '../_resolver/bazar-detail.resolver';

const routes: Routes = [
  { path: '', component: BazarListPage },
  { path: 'new', loadChildren: './bazar-new/bazar-new.module#BazarNewPageModule' },
  { path: ':id', loadChildren: './bazar-detail/bazar-detail.module#BazarDetailPageModule', resolve: {bazar: BazarDetailResolver} }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    BazarListPageModule,
    BazarNewPageModule,
    BazarDetailPageModule,
    RouterModule.forChild(routes)
  ]
})
export class BazarModule { }
