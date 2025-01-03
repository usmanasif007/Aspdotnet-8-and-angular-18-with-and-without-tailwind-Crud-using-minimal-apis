import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../Product.service'
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-entry',
  standalone: true,
  imports: [CommonModule,
    ReactiveFormsModule, // Import ReactiveFormsModule
    HttpClientModule],
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent implements OnInit {
  productForm: FormGroup;
  productId: string | null = null;
  constructor(private router: Router, private ProductService: ProductService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.productForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      price: ['', [Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]],
      description: ['', [Validators.required, Validators.minLength(10)]]
    });
   }

   ngOnInit(): void {
    this.productId = this.route.snapshot.paramMap.get('id');
    if (this.productId) {
      this.loadProductDetails(this.productId);
    }
  }

  loadProductDetails(id: string): void {
    this.ProductService.get(id).subscribe({
      next: (product) => {
        this.productForm.patchValue(product);
      },
      error: (e) => {
        alert(e.error);
      }
    });
  }
  
  onSubmit(): void {
    if (this.productForm.valid) {
      this.ProductService.create(this.productForm.value).subscribe({
        next: () => {
          this.router.navigateByUrl('/product');
        },
        error: (e) => {
          alert(e.error);
        },
        complete: () => {
          console.log('Request complete');
        }
      });
    }
  }
}
