import { NgModule } from "@angular/core";
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatRadioModule } from '@angular/material/radio'
import { MatSelectModule } from '@angular/material/select'
import { CommonModule } from "@angular/common";
import { MatPseudoCheckboxModule } from "@angular/material/core";
import { MatCheckboxModule } from '@angular/material/checkbox'

@NgModule({
    imports:[CommonModule],
    exports:[
        MatButtonModule,
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatRadioModule,
        MatSelectModule,
        MatPseudoCheckboxModule,
        MatCheckboxModule,
    ]
})

export class MaterialModule {}