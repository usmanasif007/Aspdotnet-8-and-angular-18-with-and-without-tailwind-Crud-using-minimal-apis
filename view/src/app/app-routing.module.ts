import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { ListComponent } from './components/product/list/list.component'
import { EntryComponent } from './components/product/entry/entry.component'

const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full' },
  { path: 'product', component: ListComponent },
  { path: 'product/entry', component: EntryComponent },
  { path: 'product/entry/:id', component: EntryComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }