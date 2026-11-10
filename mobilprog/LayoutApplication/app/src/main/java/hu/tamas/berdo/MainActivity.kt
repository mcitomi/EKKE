package hu.tamas.berdo

import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main_linear)
//        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
//            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
//            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
//            insets
//        }

        var textView = findViewById<TextView>(R.id.textView);

        var button = findViewById<Button>(R.id.button);

        var btnClicked = 0;

        button.setOnClickListener(View.OnClickListener {
            var myText = textView.text.toString()
            myText += "!"
            textView.text = myText
            btnClicked++;
            button.text = "Pressed: ${btnClicked}x"

        })

    }
}