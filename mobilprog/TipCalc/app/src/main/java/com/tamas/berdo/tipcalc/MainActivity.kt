package com.tamas.berdo.tipcalc

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.RadioButton
import android.widget.RadioGroup
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    private lateinit var bill: EditText
    private lateinit var radioGroup: RadioGroup
    private lateinit var button: Button


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        bill = findViewById(R.id.editTextText)
        radioGroup = findViewById(R.id.radioGroup)
        button = findViewById(R.id.button)
        button.setOnClickListener(View.OnClickListener {
            val selectedRadioBtnId = radioGroup.checkedRadioButtonId
            if(selectedRadioBtnId != -1) {
                val selectedRadioBtn = findViewById<RadioButton>(selectedRadioBtnId)
                val tip = selectedRadioBtn.text

                var intent = Intent(this, SecondActivity::class.java)

                intent.putExtra("tip", tip)
                intent.putExtra("bill", bill.text.toString().toFloatOrNull())

                startActivity(intent)
            }


        })
    }
}