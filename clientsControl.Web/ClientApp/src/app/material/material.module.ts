import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material'
import { MatTableModule } from '@angular/material'
import { MatPaginatorModule } from '@angular/material'
import { MatSortModule } from '@angular/material'
import { MatIconModule } from '@angular/material'
import { MatInputModule } from '@angular/material'



@NgModule({
  //declarations: [],
  imports: [MatButtonModule, MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatInputModule],
  exports: [MatButtonModule, MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatInputModule]
})
export class MaterialModule { }
