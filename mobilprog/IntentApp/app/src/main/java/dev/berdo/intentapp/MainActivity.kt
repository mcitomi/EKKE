package dev.berdo.intentapp

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_main)

        val button = findViewById<Button>(R.id.button)
        button.setOnClickListener(View.OnClickListener{
            // Intent létrehozása
            val intentExplicit = Intent(this, SecondActivity::class.java)   // referencia operátor, java osztályra mutat
            // Átadjuk a rendszernek hogy indítsa el
            startActivity(intentExplicit)

            // Uri = Universal Request Identifier
            val intentImplicit = Intent(Intent.ACTION_DIAL, Uri.parse("tel://1234"))
            val intentImplicit2 = Intent(Intent.ACTION_VIEW, Uri.parse("https://uni-eger.hu"))
            startActivity(intentImplicit2)

            // 5-ös anyag moodle
        })
    }
}