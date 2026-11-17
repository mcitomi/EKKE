package com.tamas.berdo.tipcalc

import android.os.Bundle
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class SecondActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_second)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val intent = getIntent()
        val bill = intent.getFloatExtra("bill", 0.0f)
        val tip = intent.getStringExtra("tip")
        var percentage = 0.0

        when (tip) {
            "10%" -> percentage = 1.10
            "15%" -> percentage = 1.15
            "17%" -> percentage = 1.17
        }

        val total = bill * percentage
        val textView = findViewById<TextView>(R.id.textView)
        textView.text = total.toString()
    }
}