
                function check(num) {
                    switch (num) {
                        case 1:
                            document.getElementById('BackgroundColour').value = document.getElementById('cpBackgroundColour').value;
                            break;
                        case 2:
                            document.getElementById('ButtonColour').value = document.getElementById('cpButtonColour').value;
                            break;
                        case 3:
                            document.getElementById('ButtonTextColour').value = document.getElementById('cpButtonTextColour').value;
                            break;
                        case 4:
                            document.getElementById('TitleColour').value = document.getElementById('cpTitleColour').value;
                            break;
                        case 5:
                            document.getElementById('MainTextColour').value = document.getElementById('cpMainTextColour').value;
                    }

                }
                function CheckName() {


                    var title = document.getElementById('Title').value;
                    var mainText = document.getElementById('MainText').value;
                    var image = document.getElementById('ImageUrl').value;
                    var buttonText = document.getElementById('ButtonText').value;
                    var buttonColour = document.getElementById('ButtonColour').value;
                    var buttonTextColour = document.getElementById('ButtonTextColour').value;
                    var titleColour = document.getElementById('TitleColour').value;
                    var mainTextColour = document.getElementById('MainTextColour').value;
                    var podColour = document.getElementById('BackgroundColour').value;


                    if (title != '#FFFFFF') {
                        document.getElementById("titleDemo").innerHTML = title;
                    }
                    if (mainText != '#FFFFFF') {
                        document.getElementById("mainTextDemo").innerHTML = mainText;
                    }
                    if (image != '#FFFFFF') {
                        document.getElementById("imgDemo").src = '/Img/' + image;
                    }
                    if (buttonText != '#FFFFFF') {
                        document.getElementById("buttonDemo").innerHTML = buttonText;
                    }
                    if (buttonColour != '#FFFFFF') {
                        document.getElementById("buttonDemo").style.backgroundColor = buttonColour;
                    }
                    if (buttonTextColour != '#FFFFFF') {
                        document.getElementById("buttonDemo").style.color = buttonTextColour;
                    }
                    if (titleColour != '#FFFFFF') {
                        document.getElementById("titleDemo").style.color = titleColour;
                    }
                    if (mainTextColour != '#FFFFFF') {
                        document.getElementById("mainTextDemo").style.color = mainTextColour;
                    }
                    if (podColour != '#FFFFFF') {
                        document.getElementById("podDemo").style.backgroundColor = podColour;
                    }

                    document.getElementById("podDemo").style.display = "block";

                    alert(document.getElementById('custom').value);

                }

               