import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntryComponent } from './entry/entry.component';
import { ListComponent } from './list/list.component';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { ListService } from './list/list.service';
import { AppInterceptor } from '../../app.interceptor';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path: '', component: ListComponent},
      {path: 'product/entry', component: EntryComponent},
    ]),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AppInterceptor, multi: true }
  ],
})
export class ProductModule { }
