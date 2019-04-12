import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material'
import { MatTableModule } from '@angular/material'
import { MatPaginatorModule } from '@angular/material'
import { MatSortModule } from '@angular/material'
import { MatIconModule } from '@angular/material'
import { MatInputModule } from '@angular/material'
import { MatMenuModule } from '@angular/material'
import { MatDialogModule } from '@angular/material'
import { MatFormFieldModule } from '@angular/material'




@NgModule({
  //declarations: [],
  imports: [MatButtonModule, MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatInputModule, MatMenuModule, MatDialogModule, MatFormFieldModule],
  exports: [MatButtonModule, MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatInputModule, MatMenuModule, MatDialogModule, MatFormFieldModule]
})
export class MaterialModule { }
