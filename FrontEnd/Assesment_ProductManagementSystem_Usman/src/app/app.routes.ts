import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', loadChildren: () => import('./components/product/product.module').then(m => m.ProductModule) },
];
