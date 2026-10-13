package dev.berdo.gyak1013

import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {


    private val TAG: String? = "MainActivity"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        Log.d(TAG, "onCreate: ")

        val text = findViewById<TextView>(R.id.textView)
        text.text = "Üdv világ!"

        val button = findViewById<Button>(R.id.button)
        button.setOnClickListener(View.OnClickListener{text.text = "Szia!"})

    }

    override fun onStart() {
        super.onStart()

        Log.d(TAG, "onStart: ")
    }

    // onresume
    override fun onResume() {
        super.onResume()

        Log.d(TAG, "onResume: ")
    }

    override fun onPause() {
        super.onPause()

        Log.d(TAG, "onPause: ")
    }

    override fun onStop() {
        super.onStop()

        Log.d(TAG, "onStop: ")
    }

    override fun onDestroy() {
        super.onDestroy()

        Log.d(TAG, "onDestroy: ")
    }


}